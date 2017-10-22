using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class FilesExplorer : Form, IDisposable
    {
        private Client cl;
        public FilesExplorer()
        {
            InitializeComponent();
        }
        public FilesExplorer(Client _cl):this()
        {
            cl = _cl;
            Init();
        }

        private async void Init()
        {
            try
            {
                string[] receivedStrings = await cl.GetLocalDrives();
                UpdateListBoxWith(receivedStrings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void UpdateListBoxWith(string[] strArr)
        {
            listBoxFilesExplorer.Items.Clear();
            listBoxFilesExplorer.Items.Add("..");

            var folders = from folder in strArr
                          where !folder.Contains('.')
                          select folder;
            foreach (string str in folders)
            {
                listBoxFilesExplorer.Items.Add(str);
            }
            listBoxFilesExplorer.Items.Add("--------------");

            var files = from file in strArr
                          where file.Contains('.')
                          select file;
            foreach (string str in files)
            {
                listBoxFilesExplorer.Items.Add(str);
            }
        }

        private async void listBoxFilesExplorer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string selectedFolder = listBoxFilesExplorer.SelectedItem.ToString();
              //  MessageBox.Show(selectedFolder);
                string[] receivedFolders = await cl.GetFolderContent(selectedFolder);
             //   MessageBox.Show(receivedFolders[1]);
                UpdateListBoxWith(receivedFolders);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FilesExplorer_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                cl.EndFileExplorer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void buttonToRoot_Click(object sender, EventArgs e)
        {
            try
            {
                string[] receivedStrings = await cl.FileExplorerToRoot();
                UpdateListBoxWith(receivedStrings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
