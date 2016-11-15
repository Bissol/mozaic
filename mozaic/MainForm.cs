using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mozaic
{
    public partial class MainForm : Form
    {
        ThumbMaker thumbMaker;// = new ThumbMaker(Properties.Settings.Default.LastPath);
        Mozaic mozaic;
        
        public MainForm()
        {
            InitializeComponent();

            textBoxCurrentDir.Text = Properties.Settings.Default.LastPath;
            textBoxImgTarget.Text = Properties.Settings.Default.ImgTargetPath;
            numericUpDownMatchGridSize.Value = Properties.Settings.Default.matchGridSize;
            numericUpDownNbColRow.Value = Properties.Settings.Default.nbColRows;
            numericUpDownTileSizeResult.Value = Properties.Settings.Default.tileSizeResult;

            bool targetExists = System.IO.File.Exists(textBoxImgTarget.Text);
            if (textBoxImgTarget.Text != "" && targetExists) pictureBoxTargetImage.Image = new Bitmap(Properties.Settings.Default.ImgTargetPath);

            string appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"mozz");
            if (!Directory.Exists(appdata)) Directory.CreateDirectory(appdata);
            Properties.Settings.Default.appData = appdata;
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
            //thumbMaker = new ThumbMaker(Properties.Settings.Default.LastPath, Properties.Settings.Default + "/tiles");
        }

        private void buttonChangeImgTarget_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Properties.Settings.Default.LastPath;
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
            this.thumbMaker = new ThumbMaker(Properties.Settings.Default.LastPath, Path.Combine(Properties.Settings.Default.appData, "tiles"));
            this.thumbMaker.Process();
        }

        private void buttonBuildMozaic_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonPrepareMozaic_Click(object sender, EventArgs e)
        {
            mozaic = new Mozaic(Path.Combine(Properties.Settings.Default.appData, "tiles"), Properties.Settings.Default.appData);
            mozaic.prepareData();
        }

        private void buttonLoadColorData_Click(object sender, EventArgs e)
        {
            mozaic = new Mozaic(Path.Combine(Properties.Settings.Default.appData, "tiles"), Properties.Settings.Default.appData);
            mozaic.loadData();
        }

        private void buttonBuildMozaic_Click_1(object sender, EventArgs e)
        {
            string resultPath = mozaic.make();

            FileStream bitmapFile = new FileStream(resultPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Image loaded = new Bitmap(bitmapFile);

            pictureBoxResult.Image = loaded;
        }

        private void numericUpDownNbColRow_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.nbColRows = (int)numericUpDownNbColRow.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDownTileSizeResult_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.tileSizeResult = (int)numericUpDownTileSizeResult.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDownMatchGridSize_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.matchGridSize = (int)numericUpDownMatchGridSize.Value;
            Properties.Settings.Default.Save();
        }
    }
}
