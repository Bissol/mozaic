namespace mozaic
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCurrentDir = new System.Windows.Forms.TextBox();
            this.buttonChangeDir = new System.Windows.Forms.Button();
            this.buttonMakeTiles = new System.Windows.Forms.Button();
            this.buttonPrepareData = new System.Windows.Forms.Button();
            this.buttonChangeImgTarget = new System.Windows.Forms.Button();
            this.textBoxImgTarget = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBuildMozaic = new System.Windows.Forms.Button();
            this.buttonLoadColorData = new System.Windows.Forms.Button();
            this.pictureBoxTargetImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.Paramètres = new System.Windows.Forms.GroupBox();
            this.numericUpDownNbColRow = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownTileSizeResult = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownMatchGridSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTargetImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.Paramètres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbColRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileSizeResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatchGridSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Répertoire courant :";
            // 
            // textBoxCurrentDir
            // 
            this.textBoxCurrentDir.Enabled = false;
            this.textBoxCurrentDir.Location = new System.Drawing.Point(119, 6);
            this.textBoxCurrentDir.Name = "textBoxCurrentDir";
            this.textBoxCurrentDir.Size = new System.Drawing.Size(258, 20);
            this.textBoxCurrentDir.TabIndex = 1;
            // 
            // buttonChangeDir
            // 
            this.buttonChangeDir.Location = new System.Drawing.Point(383, 4);
            this.buttonChangeDir.Name = "buttonChangeDir";
            this.buttonChangeDir.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeDir.TabIndex = 2;
            this.buttonChangeDir.Text = "changer";
            this.buttonChangeDir.UseVisualStyleBackColor = true;
            this.buttonChangeDir.Click += new System.EventHandler(this.buttonChangeDir_Click);
            // 
            // buttonMakeTiles
            // 
            this.buttonMakeTiles.Location = new System.Drawing.Point(15, 60);
            this.buttonMakeTiles.Name = "buttonMakeTiles";
            this.buttonMakeTiles.Size = new System.Drawing.Size(98, 23);
            this.buttonMakeTiles.TabIndex = 3;
            this.buttonMakeTiles.Text = "créer les tuiles";
            this.buttonMakeTiles.UseVisualStyleBackColor = true;
            this.buttonMakeTiles.Click += new System.EventHandler(this.buttonMakeTiles_Click);
            // 
            // buttonPrepareData
            // 
            this.buttonPrepareData.Location = new System.Drawing.Point(119, 60);
            this.buttonPrepareData.Name = "buttonPrepareData";
            this.buttonPrepareData.Size = new System.Drawing.Size(150, 23);
            this.buttonPrepareData.TabIndex = 4;
            this.buttonPrepareData.Text = "Préparer les données";
            this.buttonPrepareData.UseVisualStyleBackColor = true;
            this.buttonPrepareData.Click += new System.EventHandler(this.buttonPrepareMozaic_Click);
            // 
            // buttonChangeImgTarget
            // 
            this.buttonChangeImgTarget.Location = new System.Drawing.Point(383, 30);
            this.buttonChangeImgTarget.Name = "buttonChangeImgTarget";
            this.buttonChangeImgTarget.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeImgTarget.TabIndex = 7;
            this.buttonChangeImgTarget.Text = "changer";
            this.buttonChangeImgTarget.UseVisualStyleBackColor = true;
            this.buttonChangeImgTarget.Click += new System.EventHandler(this.buttonChangeImgTarget_Click);
            // 
            // textBoxImgTarget
            // 
            this.textBoxImgTarget.Enabled = false;
            this.textBoxImgTarget.Location = new System.Drawing.Point(119, 32);
            this.textBoxImgTarget.Name = "textBoxImgTarget";
            this.textBoxImgTarget.Size = new System.Drawing.Size(258, 20);
            this.textBoxImgTarget.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Image cible :";
            // 
            // buttonBuildMozaic
            // 
            this.buttonBuildMozaic.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonBuildMozaic.Location = new System.Drawing.Point(705, 12);
            this.buttonBuildMozaic.Name = "buttonBuildMozaic";
            this.buttonBuildMozaic.Size = new System.Drawing.Size(150, 23);
            this.buttonBuildMozaic.TabIndex = 9;
            this.buttonBuildMozaic.Text = "Construire mozaique";
            this.buttonBuildMozaic.UseVisualStyleBackColor = false;
            this.buttonBuildMozaic.Click += new System.EventHandler(this.buttonBuildMozaic_Click_1);
            // 
            // buttonLoadColorData
            // 
            this.buttonLoadColorData.Location = new System.Drawing.Point(549, 12);
            this.buttonLoadColorData.Name = "buttonLoadColorData";
            this.buttonLoadColorData.Size = new System.Drawing.Size(150, 23);
            this.buttonLoadColorData.TabIndex = 10;
            this.buttonLoadColorData.Text = "Charger les données";
            this.buttonLoadColorData.UseVisualStyleBackColor = true;
            this.buttonLoadColorData.Click += new System.EventHandler(this.buttonLoadColorData_Click);
            // 
            // pictureBoxTargetImage
            // 
            this.pictureBoxTargetImage.Location = new System.Drawing.Point(6, 272);
            this.pictureBoxTargetImage.Name = "pictureBoxTargetImage";
            this.pictureBoxTargetImage.Size = new System.Drawing.Size(413, 268);
            this.pictureBoxTargetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTargetImage.TabIndex = 11;
            this.pictureBoxTargetImage.TabStop = false;
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.Location = new System.Drawing.Point(448, 272);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(407, 268);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxResult.TabIndex = 12;
            this.pictureBoxResult.TabStop = false;
            // 
            // Paramètres
            // 
            this.Paramètres.Controls.Add(this.label5);
            this.Paramètres.Controls.Add(this.numericUpDownMatchGridSize);
            this.Paramètres.Controls.Add(this.label4);
            this.Paramètres.Controls.Add(this.numericUpDownTileSizeResult);
            this.Paramètres.Controls.Add(this.label3);
            this.Paramètres.Controls.Add(this.numericUpDownNbColRow);
            this.Paramètres.Location = new System.Drawing.Point(12, 100);
            this.Paramètres.Name = "Paramètres";
            this.Paramètres.Size = new System.Drawing.Size(843, 157);
            this.Paramètres.TabIndex = 13;
            this.Paramètres.TabStop = false;
            this.Paramètres.Text = "Paramètres";
            // 
            // numericUpDownNbColRow
            // 
            this.numericUpDownNbColRow.Location = new System.Drawing.Point(639, 14);
            this.numericUpDownNbColRow.Name = "numericUpDownNbColRow";
            this.numericUpDownNbColRow.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownNbColRow.TabIndex = 0;
            this.numericUpDownNbColRow.ValueChanged += new System.EventHandler(this.numericUpDownNbColRow_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nb lignes/colonnes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Taille tuile résultat";
            // 
            // numericUpDownTileSizeResult
            // 
            this.numericUpDownTileSizeResult.Location = new System.Drawing.Point(639, 44);
            this.numericUpDownTileSizeResult.Name = "numericUpDownTileSizeResult";
            this.numericUpDownTileSizeResult.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownTileSizeResult.TabIndex = 2;
            this.numericUpDownTileSizeResult.ValueChanged += new System.EventHandler(this.numericUpDownTileSizeResult_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(534, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Taille grille match";
            // 
            // numericUpDownMatchGridSize
            // 
            this.numericUpDownMatchGridSize.Location = new System.Drawing.Point(639, 71);
            this.numericUpDownMatchGridSize.Name = "numericUpDownMatchGridSize";
            this.numericUpDownMatchGridSize.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownMatchGridSize.TabIndex = 4;
            this.numericUpDownMatchGridSize.ValueChanged += new System.EventHandler(this.numericUpDownMatchGridSize_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 552);
            this.Controls.Add(this.Paramètres);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.pictureBoxTargetImage);
            this.Controls.Add(this.buttonLoadColorData);
            this.Controls.Add(this.buttonBuildMozaic);
            this.Controls.Add(this.buttonChangeImgTarget);
            this.Controls.Add(this.textBoxImgTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonPrepareData);
            this.Controls.Add(this.buttonMakeTiles);
            this.Controls.Add(this.buttonChangeDir);
            this.Controls.Add(this.textBoxCurrentDir);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Mozz";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTargetImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.Paramètres.ResumeLayout(false);
            this.Paramètres.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbColRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileSizeResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatchGridSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCurrentDir;
        private System.Windows.Forms.Button buttonChangeDir;
        private System.Windows.Forms.Button buttonMakeTiles;
        private System.Windows.Forms.Button buttonPrepareData;
        private System.Windows.Forms.Button buttonChangeImgTarget;
        private System.Windows.Forms.TextBox textBoxImgTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBuildMozaic;
        private System.Windows.Forms.Button buttonLoadColorData;
        private System.Windows.Forms.PictureBox pictureBoxTargetImage;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.GroupBox Paramètres;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownNbColRow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownTileSizeResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownMatchGridSize;
    }
}

