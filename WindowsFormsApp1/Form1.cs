using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using MediaToolkit;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Boolean format = true;
        private async void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fdb = new FolderBrowserDialog() { Description = "Lütfen Bir Klasör Seciniz" })
            {
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("İndirme Başladı Lütfen Bekleyiniz...");
                    var yt = YouTube.Default;
                    var video = await yt.GetVideoAsync(textBox1.Text);
                    File.WriteAllBytes(fdb.SelectedPath + @"\" + video.FullName, await video.GetBytesAsync());
                    var inputfile = new MediaToolkit.Model.MediaFile { Filename = fdb.SelectedPath + @"\" + video.FullName };
                    var ouptputfile = new MediaToolkit.Model.MediaFile { Filename = $"{fdb.SelectedPath + @"\" + video.FullName }.mp3" };


                    using (var ening = new Engine())
                    {
                        ening.GetMetadata(inputfile);
                        ening.Convert(inputfile, ouptputfile);
                    }
                    if (format == true)
                    {
                        File.Delete(fdb.SelectedPath + @"\" + video.FullName);
                    }
                    else
                    {
                        File.Delete($"{fdb.SelectedPath + @"\" + video.FullName }.mp3");
                    }

                    progressBar1.Value = 100;
                    MessageBox.Show("İndiriliyor");
                }

            }

        
        }

 

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/nZPv7sV5tc"); 

        }

        private void button3_Click(object sender, EventArgs e)
        {
                   System.Diagnostics.Process.Start("http://www.frigos.cf/ "); 
        }
    }
}