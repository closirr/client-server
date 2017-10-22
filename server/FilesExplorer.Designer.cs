namespace server
{
    partial class FilesExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxFilesExplorer = new System.Windows.Forms.ListBox();
            this.buttonToRoot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxFilesExplorer
            // 
            this.listBoxFilesExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFilesExplorer.FormattingEnabled = true;
            this.listBoxFilesExplorer.Location = new System.Drawing.Point(12, 12);
            this.listBoxFilesExplorer.Name = "listBoxFilesExplorer";
            this.listBoxFilesExplorer.Size = new System.Drawing.Size(176, 238);
            this.listBoxFilesExplorer.TabIndex = 0;
            this.listBoxFilesExplorer.DoubleClick += new System.EventHandler(this.listBoxFilesExplorer_DoubleClick);
            // 
            // buttonToRoot
            // 
            this.buttonToRoot.Location = new System.Drawing.Point(195, 13);
            this.buttonToRoot.Name = "buttonToRoot";
            this.buttonToRoot.Size = new System.Drawing.Size(75, 23);
            this.buttonToRoot.TabIndex = 1;
            this.buttonToRoot.Text = "To RooT";
            this.buttonToRoot.UseVisualStyleBackColor = true;
            this.buttonToRoot.Click += new System.EventHandler(this.buttonToRoot_Click);
            // 
            // FilesExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonToRoot);
            this.Controls.Add(this.listBoxFilesExplorer);
            this.Name = "FilesExplorer";
            this.Text = "FilesExplorer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FilesExplorer_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxFilesExplorer;
        private System.Windows.Forms.Button buttonToRoot;
    }
}