namespace server
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonScreen = new System.Windows.Forms.Button();
            this.pictureBoxScreenshot = new System.Windows.Forms.PictureBox();
            this.buttonNewVersion = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonVideo = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonFilesExplorer = new System.Windows.Forms.Button();
            this.buttonStopVideo = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.numericUpDownDelay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxOwn = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxClients
            // 
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.Location = new System.Drawing.Point(12, 12);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(156, 147);
            this.listBoxClients.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(173, 12);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 364);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "tobiPizda";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonScreen
            // 
            this.buttonScreen.Location = new System.Drawing.Point(173, 135);
            this.buttonScreen.Name = "buttonScreen";
            this.buttonScreen.Size = new System.Drawing.Size(75, 23);
            this.buttonScreen.TabIndex = 5;
            this.buttonScreen.Text = "screen";
            this.buttonScreen.UseVisualStyleBackColor = true;
            this.buttonScreen.Click += new System.EventHandler(this.buttonScreen_Click);
            // 
            // pictureBoxScreenshot
            // 
            this.pictureBoxScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxScreenshot.Location = new System.Drawing.Point(347, 13);
            this.pictureBoxScreenshot.Name = "pictureBoxScreenshot";
            this.pictureBoxScreenshot.Size = new System.Drawing.Size(486, 372);
            this.pictureBoxScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxScreenshot.TabIndex = 6;
            this.pictureBoxScreenshot.TabStop = false;
            // 
            // buttonNewVersion
            // 
            this.buttonNewVersion.Location = new System.Drawing.Point(12, 217);
            this.buttonNewVersion.Name = "buttonNewVersion";
            this.buttonNewVersion.Size = new System.Drawing.Size(75, 23);
            this.buttonNewVersion.TabIndex = 7;
            this.buttonNewVersion.Text = "New Version";
            this.buttonNewVersion.UseVisualStyleBackColor = true;
            this.buttonNewVersion.Click += new System.EventHandler(this.buttonNewVersion_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(109, 217);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(203, 96);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "svchost2";
            // 
            // buttonVideo
            // 
            this.buttonVideo.Location = new System.Drawing.Point(173, 106);
            this.buttonVideo.Name = "buttonVideo";
            this.buttonVideo.Size = new System.Drawing.Size(75, 23);
            this.buttonVideo.TabIndex = 9;
            this.buttonVideo.Text = "video";
            this.buttonVideo.UseVisualStyleBackColor = true;
            this.buttonVideo.Click += new System.EventHandler(this.buttonVideo_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(13, 247);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 10;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(249, 368);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Enable";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonFilesExplorer
            // 
            this.buttonFilesExplorer.Location = new System.Drawing.Point(254, 74);
            this.buttonFilesExplorer.Name = "buttonFilesExplorer";
            this.buttonFilesExplorer.Size = new System.Drawing.Size(75, 23);
            this.buttonFilesExplorer.TabIndex = 12;
            this.buttonFilesExplorer.Text = "FilesExplorer";
            this.buttonFilesExplorer.UseVisualStyleBackColor = true;
            this.buttonFilesExplorer.Click += new System.EventHandler(this.buttonFilesExplorer_Click);
            // 
            // buttonStopVideo
            // 
            this.buttonStopVideo.Location = new System.Drawing.Point(254, 106);
            this.buttonStopVideo.Name = "buttonStopVideo";
            this.buttonStopVideo.Size = new System.Drawing.Size(75, 23);
            this.buttonStopVideo.TabIndex = 13;
            this.buttonStopVideo.Text = "Stop Video";
            this.buttonStopVideo.UseVisualStyleBackColor = true;
            this.buttonStopVideo.Click += new System.EventHandler(this.buttonStopVideo_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(101, 185);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(85, 17);
            this.checkBox2.TabIndex = 14;
            this.checkBox2.Text = "save images";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // numericUpDownDelay
            // 
            this.numericUpDownDelay.Location = new System.Drawing.Point(192, 182);
            this.numericUpDownDelay.Maximum = new decimal(new int[] {
            888888,
            0,
            0,
            0});
            this.numericUpDownDelay.Name = "numericUpDownDelay";
            this.numericUpDownDelay.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDelay.TabIndex = 15;
            this.numericUpDownDelay.ValueChanged += new System.EventHandler(this.numericUpDownDelay_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "delay";
            // 
            // checkBoxOwn
            // 
            this.checkBoxOwn.AutoSize = true;
            this.checkBoxOwn.Location = new System.Drawing.Point(19, 185);
            this.checkBoxOwn.Name = "checkBoxOwn";
            this.checkBoxOwn.Size = new System.Drawing.Size(68, 17);
            this.checkBoxOwn.TabIndex = 17;
            this.checkBoxOwn.Text = "Own Img";
            this.checkBoxOwn.UseVisualStyleBackColor = true;
            this.checkBoxOwn.CheckedChanged += new System.EventHandler(this.checkBoxOwn_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 417);
            this.Controls.Add(this.checkBoxOwn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownDelay);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.buttonStopVideo);
            this.Controls.Add(this.buttonFilesExplorer);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonVideo);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonNewVersion);
            this.Controls.Add(this.pictureBoxScreenshot);
            this.Controls.Add(this.buttonScreen);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.listBoxClients);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonScreen;
        private System.Windows.Forms.PictureBox pictureBoxScreenshot;
        private System.Windows.Forms.Button buttonNewVersion;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonVideo;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonFilesExplorer;
        private System.Windows.Forms.Button buttonStopVideo;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownDelay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxOwn;
    }
}

