using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoProcess {
    public partial class frmMain : Form {
        [DllImport("Kernel32.dll")]
        public static extern bool AllocConsole ();
        [DllImport("Kernel32.dll")]
        public static extern bool FreeConsole ();
        public frmMain () {
            InitializeComponent();
            AllocConsole();
            Console.WriteLine("");
        }

        private void btnBrowse_Click ( object sender, EventArgs e ) {
            fbBrowse.ShowDialog();
            txtPhotoPath.Text = fbBrowse.SelectedPath;
        }

        private void frmMain_Load ( object sender, EventArgs e ) {

        }

        private void btnStart_Click ( object sender, EventArgs e ) {
            bgWorker.RunWorkerAsync();
        }

        private void bgWorker_DoWork ( object sender, DoWorkEventArgs e ) {
            clsMain Main = new clsMain(txtPhotoPath.Text);
            Main.CopyFolder(chkUseBackup.Checked);
            if ( chkRename.Checked ) Main.RenameFile();
            if ( chkPackImage.Checked ) Main.PackImage();
            if ( chkPackZIP.Checked ) Main.PackZIP();

        }
    }
}
