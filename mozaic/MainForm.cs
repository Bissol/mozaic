using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mozaic
{
    public partial class MainForm : Form
    {
        ThumbMaker thumbMaker = new ThumbMaker(Properties.Settings.Default.LastPath);
        Mozaic mozaic;
        
        public MainForm()
        {
            InitializeComponent();
            textBoxCurrentDir.Text = Properties.Settings.Default.LastPath;
            textBoxImgTarget.Text = Properties.Settings.Default.ImgTargetPath;
            if (textBoxImgTarget.Text != "") pictureBoxTargetImage.Image = new Bitmap(Properties.Settings.Default.ImgTargetPath);
        }

        private void buttonChangeDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            folderBrowser.Description = "Choisis un répertoire de travail";
            folderBrowser.ShowNewFolderButton = true;
            folderBrowser.SelectedPath = Properties.Settings.Default.LastPath;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {

                if (!String.IsNullOrEmpty(Properties.Settings.Default.LastPath))
                {
                    Properties.Settings.Default.LastPath = folderBrowser.SelectedPath;
                }

                Properties.Settings.Default.LastPath = folderBrowser.SelectedPath;
                Properties.Settings.Default.Save();
            }

            textBoxCurrentDir.Text = Properties.Settings.Default.LastPath;
            thumbMaker = new ThumbMaker(Properties.Settings.Default.LastPath);
        }

        private void buttonChangeImgTarget_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(Properties.Settings.Default.ImgTargetPath))
                {
                    Properties.Settings.Default.ImgTargetPath = openFileDialog1.FileName;
                }

                Properties.Settings.Default.ImgTargetPath = openFileDialog1.FileName;
                Properties.Settings.Default.Save();
                textBoxImgTarget.Text = Properties.Settings.Default.ImgTargetPath;
                pictureBoxTargetImage.Image = new Bitmap(Properties.Settings.Default.ImgTargetPath);
            }
        }

        private void buttonMakeTiles_Click(object sender, EventArgs e)
        {
            this.thumbMaker.Process();
        }

        private void buttonBuildMozaic_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonPrepareMozaic_Click(object sender, EventArgs e)
        {
            mozaic = new Mozaic(Properties.Settings.Default.LastPath + "/tiles");
            mozaic.prepareData();
        }

        private void buttonLoadColorData_Click(object sender, EventArgs e)
        {
            mozaic = new Mozaic(Properties.Settings.Default.LastPath + "/tiles");
            mozaic.loadData();
        }

        private void buttonBuildMozaic_Click_1(object sender, EventArgs e)
        {
            mozaic.make();
        }
    }
}
