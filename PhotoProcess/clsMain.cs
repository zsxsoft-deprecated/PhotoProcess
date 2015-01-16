using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhotoProcess {
    class clsMain {
        private string strPath = "";
        private List<string> lstPath = new List<string>();
        private bool bolDebug = false;

        private void Log ( string strOutput ) {
            if ( this.bolDebug ) {
                Console.WriteLine(strOutput);
            }
        }
        public clsMain ( string strPath, bool bolDebug = true ) {
            this.strPath = strPath;
            this.bolDebug = bolDebug;
        }

        private bool Copy ( string from, string to ) {
            foreach ( string file in Directory.GetFiles(from) ) {
                if ( Regex.Match(file, "(jpg|jpeg|bmp|png)$", RegexOptions.IgnoreCase).Success ) {
                    File.Copy(file, to + Path.GetFileName(file), true);
                }

            }

            foreach ( string file in Directory.GetDirectories(from) )
                this.Copy(file, to);
            return true;
        }

        public bool CopyFolder ( bool bolCopyFolder = false ) {
            this.Log("扫描文件夹....");

            string[] dirs = Directory.GetDirectories(this.strPath);
            foreach ( string dir in dirs ) {
                string from = dir;
                string to = (bolCopyFolder ? Path.GetDirectoryName(dir) + "\\" + Path.GetFileName(dir) + "_Copy\\" : dir);

                if ( !Directory.Exists(to) ) Directory.CreateDirectory(to);
                Console.WriteLine(dir);

                if ( bolCopyFolder ) {
                    this.Copy(from, to);
                }

                lstPath.Add(to);
            }

            return true;
        }

        public bool RenameFile () {
            this.Log("重命名文件....");
            this.lstPath.ForEach(delegate( string strPath ) {
                string[] files = Directory.GetFiles(strPath);
                foreach ( string file in files ) {
                    string strID = Regex.Replace(Path.GetFileName(file), "\\D", "");
                    if ( file.Contains("ld") || file.Contains("LD") ) strID += "ld";
                    string newFile = Path.GetDirectoryName(file) + "\\" + strID + Path.GetExtension(file);
                    if ( file != newFile ) {
                        try {
                            File.Move(file, newFile);
                            this.Log(Path.GetFileName(file) + " -> " + Path.GetFileName(newFile));
                        }
                        catch ( Exception e ) {
                            Console.WriteLine("【出错】 - " + file + " - " + e.ToString());
                        }
                    }
                }
            });
            return true;

        }

        public bool PackImage () {
            this.lstPath.ForEach(delegate( string strPath ) {
                this.Log("压缩图片...");
                string[] files = Directory.GetFiles(strPath);
                foreach ( string file in files ) {
                    if ( FormatImage(file) ) {
                        this.Log(file);
                    }
                    else {
                        Console.WriteLine("【出错】" + file);
                    }

                }
            });
            return true;
        }

        public bool PackZIP () {
            this.lstPath.ForEach(delegate( string strPath ) {
                this.Log("打包为ZIP...");
                string strZipPath = Path.GetDirectoryName(strPath) +  ".zip";
                FileStream zipFileToOpen = new FileStream(strZipPath, FileMode.Create);
                ZipArchive archive = new ZipArchive(zipFileToOpen, ZipArchiveMode.Create);
                System.Reflection.Assembly assemble = System.Reflection.Assembly.GetExecutingAssembly();
                string[] files = Directory.GetFiles(strPath);
                foreach ( string file in files ) {
                    string filename = System.IO.Path.GetFileName(file);
                    ZipArchiveEntry readMeEntry = archive.CreateEntry(filename);
                    using ( System.IO.Stream stream = readMeEntry.Open() ) {
                        byte[] bytes = System.IO.File.ReadAllBytes(file);
                        stream.Write(bytes, 0, bytes.Length);
                    }
                }
                archive.Dispose();
                zipFileToOpen.Dispose();
            });
            return true;
        }


        private static bool FormatImage ( string strFile ) {
            FileStream fsFile = new FileStream(strFile, FileMode.Open);
            Image iSource = Image.FromStream(fsFile);
            Bitmap bitDraw = new Bitmap(307, 437, PixelFormat.Format24bppRgb);
            Graphics gSource = Graphics.FromImage(bitDraw);
            ImageFormat tFormat = iSource.RawFormat;
            EncoderParameters ep = new EncoderParameters();
            long[] lngEncodeParm = { 70 }; // 80为压缩值
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, lngEncodeParm);
            string outputFile = Path.GetDirectoryName(strFile) + "\\" + Path.GetFileNameWithoutExtension(strFile);
            ep.Param[0] = eParam;
            try {
                gSource.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gSource.SmoothingMode = SmoothingMode.HighQuality;
                gSource.CompositingQuality = CompositingQuality.HighQuality;
                gSource.DrawImage(iSource, new Rectangle(0, 0, 307, 437), new Rectangle(0, 0, iSource.Width, iSource.Height), GraphicsUnit.Pixel);
                gSource.Dispose();
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for ( int x = 0; x < arrayICI.Length; x++ ) {
                    if ( arrayICI[x].FormatDescription.Equals("JPEG") ) {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }

                if ( jpegICIinfo != null ) {
                    bitDraw.Save(outputFile + ".tmp", jpegICIinfo, ep);
                }
                else {
                    bitDraw.Save(outputFile + ".tmp", tFormat);
                }
                return true;
            }
            catch {
                return false;
            }
            finally {
                iSource.Dispose();
                bitDraw.Dispose();
                fsFile.Dispose();
                if ( File.Exists(strFile) ) {
                    File.Delete(strFile);
                }
                if ( File.Exists(outputFile + ".jpg") ) {
                    File.Delete(outputFile + ".jpg");
                }
                if ( File.Exists(outputFile + ".tmp") ) {
                    File.Move(outputFile + ".tmp", outputFile + ".jpg");
                }
            }
        }


    }
}
