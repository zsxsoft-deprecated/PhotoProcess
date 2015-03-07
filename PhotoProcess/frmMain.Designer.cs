namespace PhotoProcess
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhotoPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkRename = new System.Windows.Forms.CheckBox();
            this.chkPackZIP = new System.Windows.Forms.CheckBox();
            this.chkPackImage = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fbBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.chkUseBackup = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "学籍照存放目录";
            // 
            // txtPhotoPath
            // 
            this.txtPhotoPath.Location = new System.Drawing.Point(131, 22);
            this.txtPhotoPath.Name = "txtPhotoPath";
            this.txtPhotoPath.Size = new System.Drawing.Size(178, 21);
            this.txtPhotoPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(326, 21);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "浏览";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkRename
            // 
            this.chkRename.AutoSize = true;
            this.chkRename.Checked = true;
            this.chkRename.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRename.Location = new System.Drawing.Point(79, 57);
            this.chkRename.Name = "chkRename";
            this.chkRename.Size = new System.Drawing.Size(144, 16);
            this.chkRename.TabIndex = 3;
            this.chkRename.Text = "重命名文件名为学籍号";
            this.chkRename.UseVisualStyleBackColor = true;
            // 
            // chkPackZIP
            // 
            this.chkPackZIP.AutoSize = true;
            this.chkPackZIP.Checked = true;
            this.chkPackZIP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPackZIP.Location = new System.Drawing.Point(223, 57);
            this.chkPackZIP.Name = "chkPackZIP";
            this.chkPackZIP.Size = new System.Drawing.Size(78, 16);
            this.chkPackZIP.TabIndex = 4;
            this.chkPackZIP.Text = "压缩为ZIP";
            this.chkPackZIP.UseVisualStyleBackColor = true;
            // 
            // chkPackImage
            // 
            this.chkPackImage.AutoSize = true;
            this.chkPackImage.Checked = true;
            this.chkPackImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPackImage.Location = new System.Drawing.Point(79, 79);
            this.chkPackImage.Name = "chkPackImage";
            this.chkPackImage.Size = new System.Drawing.Size(282, 16);
            this.chkPackImage.TabIndex = 5;
            this.chkPackImage.Text = "照片批量转为jpg格式、20K以下、113 x 149像素";
            this.chkPackImage.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(164, 104);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "批量处理";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "本程序由福州三十六中2013届学生郑世新制作。";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            // 
            // chkUseBackup
            // 
            this.chkUseBackup.AutoSize = true;
            this.chkUseBackup.Checked = true;
            this.chkUseBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseBackup.Location = new System.Drawing.Point(303, 57);
            this.chkUseBackup.Name = "chkUseBackup";
            this.chkUseBackup.Size = new System.Drawing.Size(72, 16);
            this.chkUseBackup.TabIndex = 9;
            this.chkUseBackup.Text = "使用副本";
            this.chkUseBackup.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 180);
            this.Controls.Add(this.chkUseBackup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chkPackImage);
            this.Controls.Add(this.chkPackZIP);
            this.Controls.Add(this.chkRename);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPhotoPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学籍照处理器";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhotoPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox chkRename;
        private System.Windows.Forms.CheckBox chkPackZIP;
        private System.Windows.Forms.CheckBox chkPackImage;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog fbBrowse;
        public System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.CheckBox chkUseBackup;
    }
}

