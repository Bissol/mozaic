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

        public MainForm()
        {
            InitializeComponent();
            textBoxCurrentDir.Text = Properties.Settings.Default.LastPath;
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

            textBoxCurrentDir.Text = folderBrowser.SelectedPath;
        }

        private void buttonMakeTiles_Click(object sender, EventArgs e)
        {
            this.thumbMaker.Process();
        }

        private void buttonBuildMozaic_Click(object sender, EventArgs e)
        {
            Mozaic moz = new Mozaic(Properties.Settings.Default.LastPath + "/tiles");
            moz.build();
        }
    }
}
