﻿namespace mozaic
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTargetImage)).BeginInit();
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
            this.buttonMakeTiles.Location = new System.Drawing.Point(109, 465);
            this.buttonMakeTiles.Name = "buttonMakeTiles";
            this.buttonMakeTiles.Size = new System.Drawing.Size(98, 23);
            this.buttonMakeTiles.TabIndex = 3;
            this.buttonMakeTiles.Text = "créer les tuiles";
            this.buttonMakeTiles.UseVisualStyleBackColor = true;
            this.buttonMakeTiles.Click += new System.EventHandler(this.buttonMakeTiles_Click);
            // 
            // buttonPrepareData
            // 
            this.buttonPrepareData.Location = new System.Drawing.Point(511, 436);
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
            this.buttonBuildMozaic.Location = new System.Drawing.Point(511, 465);
            this.buttonBuildMozaic.Name = "buttonBuildMozaic";
            this.buttonBuildMozaic.Size = new System.Drawing.Size(150, 23);
            this.buttonBuildMozaic.TabIndex = 9;
            this.buttonBuildMozaic.Text = "Construire mozaique";
            this.buttonBuildMozaic.UseVisualStyleBackColor = true;
            this.buttonBuildMozaic.Click += new System.EventHandler(this.buttonBuildMozaic_Click_1);
            // 
            // buttonLoadColorData
            // 
            this.buttonLoadColorData.Location = new System.Drawing.Point(355, 436);
            this.buttonLoadColorData.Name = "buttonLoadColorData";
            this.buttonLoadColorData.Size = new System.Drawing.Size(150, 23);
            this.buttonLoadColorData.TabIndex = 10;
            this.buttonLoadColorData.Text = "Charger les données";
            this.buttonLoadColorData.UseVisualStyleBackColor = true;
            this.buttonLoadColorData.Click += new System.EventHandler(this.buttonLoadColorData_Click);
            // 
            // pictureBoxTargetImage
            // 
            this.pictureBoxTargetImage.Location = new System.Drawing.Point(15, 77);
            this.pictureBoxTargetImage.Name = "pictureBoxTargetImage";
            this.pictureBoxTargetImage.Size = new System.Drawing.Size(343, 268);
            this.pictureBoxTargetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTargetImage.TabIndex = 11;
            this.pictureBoxTargetImage.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 500);
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
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTargetImage)).EndInit();
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
    }
}

