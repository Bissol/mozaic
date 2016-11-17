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
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownBrightnessCorrectionFactor = new System.Windows.Forms.NumericUpDown();
            this.checkBoxFastSearch = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownWRelIntensity = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownWIntensity = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownWRGb = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownMatchGridSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownTileSizeResult = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownNbColRow = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownPenaltyReuse = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTargetImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.Paramètres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrightnessCorrectionFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWRelIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWRGb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatchGridSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileSizeResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbColRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPenaltyReuse)).BeginInit();
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
            this.Paramètres.Controls.Add(this.label10);
            this.Paramètres.Controls.Add(this.numericUpDownPenaltyReuse);
            this.Paramètres.Controls.Add(this.label9);
            this.Paramètres.Controls.Add(this.numericUpDownBrightnessCorrectionFactor);
            this.Paramètres.Controls.Add(this.checkBoxFastSearch);
            this.Paramètres.Controls.Add(this.label6);
            this.Paramètres.Controls.Add(this.numericUpDownWRelIntensity);
            this.Paramètres.Controls.Add(this.label7);
            this.Paramètres.Controls.Add(this.numericUpDownWIntensity);
            this.Paramètres.Controls.Add(this.label8);
            this.Paramètres.Controls.Add(this.numericUpDownWRGb);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(534, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Correction luminosité";
            // 
            // numericUpDownBrightnessCorrectionFactor
            // 
            this.numericUpDownBrightnessCorrectionFactor.Location = new System.Drawing.Point(639, 101);
            this.numericUpDownBrightnessCorrectionFactor.Name = "numericUpDownBrightnessCorrectionFactor";
            this.numericUpDownBrightnessCorrectionFactor.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownBrightnessCorrectionFactor.TabIndex = 14;
            this.numericUpDownBrightnessCorrectionFactor.ValueChanged += new System.EventHandler(this.numericUpDownBrightnessCorrectionFactor_ValueChanged);
            // 
            // checkBoxFastSearch
            // 
            this.checkBoxFastSearch.AutoSize = true;
            this.checkBoxFastSearch.Location = new System.Drawing.Point(235, 17);
            this.checkBoxFastSearch.Name = "checkBoxFastSearch";
            this.checkBoxFastSearch.Size = new System.Drawing.Size(99, 17);
            this.checkBoxFastSearch.TabIndex = 13;
            this.checkBoxFastSearch.Text = "Tuiles indexées";
            this.checkBoxFastSearch.UseVisualStyleBackColor = true;
            this.checkBoxFastSearch.CheckedChanged += new System.EventHandler(this.checkBoxFastSearch_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(355, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Poids intensité relative";
            // 
            // numericUpDownWRelIntensity
            // 
            this.numericUpDownWRelIntensity.Location = new System.Drawing.Point(473, 71);
            this.numericUpDownWRelIntensity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownWRelIntensity.Name = "numericUpDownWRelIntensity";
            this.numericUpDownWRelIntensity.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownWRelIntensity.TabIndex = 10;
            this.numericUpDownWRelIntensity.ValueChanged += new System.EventHandler(this.numericUpDownWRelIntensity_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(392, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Poids intensité";
            // 
            // numericUpDownWIntensity
            // 
            this.numericUpDownWIntensity.Location = new System.Drawing.Point(473, 44);
            this.numericUpDownWIntensity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownWIntensity.Name = "numericUpDownWIntensity";
            this.numericUpDownWIntensity.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownWIntensity.TabIndex = 8;
            this.numericUpDownWIntensity.ValueChanged += new System.EventHandler(this.numericUpDownWIntensity_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(408, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Poids RGB";
            // 
            // numericUpDownWRGb
            // 
            this.numericUpDownWRGb.Location = new System.Drawing.Point(473, 14);
            this.numericUpDownWRGb.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownWRGb.Name = "numericUpDownWRGb";
            this.numericUpDownWRGb.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownWRGb.TabIndex = 6;
            this.numericUpDownWRGb.ValueChanged += new System.EventHandler(this.numericUpDownWRGb_ValueChanged);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nb lignes/colonnes";
            // 
            // numericUpDownNbColRow
            // 
            this.numericUpDownNbColRow.Location = new System.Drawing.Point(639, 14);
            this.numericUpDownNbColRow.Name = "numericUpDownNbColRow";
            this.numericUpDownNbColRow.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownNbColRow.TabIndex = 0;
            this.numericUpDownNbColRow.ValueChanged += new System.EventHandler(this.numericUpDownNbColRow_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(368, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Pénalité répétition";
            // 
            // numericUpDownPenaltyReuse
            // 
            this.numericUpDownPenaltyReuse.Location = new System.Drawing.Point(473, 99);
            this.numericUpDownPenaltyReuse.Name = "numericUpDownPenaltyReuse";
            this.numericUpDownPenaltyReuse.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownPenaltyReuse.TabIndex = 16;
            this.numericUpDownPenaltyReuse.ValueChanged += new System.EventHandler(this.numericUpDownPenaltyReuse_ValueChanged);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrightnessCorrectionFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWRelIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWRGb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatchGridSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileSizeResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbColRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPenaltyReuse)).EndInit();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownWRelIntensity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownWIntensity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownWRGb;
        private System.Windows.Forms.CheckBox checkBoxFastSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownBrightnessCorrectionFactor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownPenaltyReuse;
    }
}

