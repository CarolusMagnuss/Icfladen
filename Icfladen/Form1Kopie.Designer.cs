﻿namespace Icfladen
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.ICFTree = new System.Windows.Forms.TreeView();
            this.LadeButton = new System.Windows.Forms.Button();
            this.Ausgabe = new System.Windows.Forms.Label();
            this.ICFTabelle = new System.Windows.Forms.DataGridView();
            this.Ansichtwechsel = new System.Windows.Forms.Button();
            this.Bearbeitungstabelle = new System.Windows.Forms.DataGridView();
            this.Change = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ICFTabelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bearbeitungstabelle)).BeginInit();
            this.SuspendLayout();
            // 
            // ICFTree
            // 
            this.ICFTree.Location = new System.Drawing.Point(28, 20);
            this.ICFTree.Name = "ICFTree";
            this.ICFTree.Size = new System.Drawing.Size(938, 334);
            this.ICFTree.TabIndex = 0;
            // 
            // LadeButton
            // 
            this.LadeButton.Location = new System.Drawing.Point(977, 294);
            this.LadeButton.Name = "LadeButton";
            this.LadeButton.Size = new System.Drawing.Size(106, 44);
            this.LadeButton.TabIndex = 1;
            this.LadeButton.Text = "Lade Datei";
            this.LadeButton.UseVisualStyleBackColor = true;
            this.LadeButton.Click += new System.EventHandler(this.LadeButton_Click);
            // 
            // Ausgabe
            // 
            this.Ausgabe.AutoSize = true;
            this.Ausgabe.Location = new System.Drawing.Point(977, 43);
            this.Ausgabe.Name = "Ausgabe";
            this.Ausgabe.Size = new System.Drawing.Size(35, 13);
            this.Ausgabe.TabIndex = 3;
            this.Ausgabe.Text = "label1";
            // 
            // ICFTabelle
            // 
            this.ICFTabelle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ICFTabelle.Location = new System.Drawing.Point(18, 25);
            this.ICFTabelle.Name = "ICFTabelle";
            this.ICFTabelle.Size = new System.Drawing.Size(953, 329);
            this.ICFTabelle.TabIndex = 4;
            this.ICFTabelle.Visible = false;
            // 
            // Ansichtwechsel
            // 
            this.Ansichtwechsel.Location = new System.Drawing.Point(977, 241);
            this.Ansichtwechsel.Name = "Ansichtwechsel";
            this.Ansichtwechsel.Size = new System.Drawing.Size(106, 47);
            this.Ansichtwechsel.TabIndex = 5;
            this.Ansichtwechsel.Text = "Tabelle oder Tree";
            this.Ansichtwechsel.UseVisualStyleBackColor = true;
            this.Ansichtwechsel.Click += new System.EventHandler(this.Ansichtwechsel_Click);
            // 
            // Bearbeitungstabelle
            // 
            this.Bearbeitungstabelle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Bearbeitungstabelle.Location = new System.Drawing.Point(12, 360);
            this.Bearbeitungstabelle.Name = "Bearbeitungstabelle";
            this.Bearbeitungstabelle.Size = new System.Drawing.Size(953, 88);
            this.Bearbeitungstabelle.TabIndex = 6;
            // 
            // Change
            // 
            this.Change.Location = new System.Drawing.Point(977, 344);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(106, 47);
            this.Change.TabIndex = 7;
            this.Change.Text = "Änderungen Übernehmen";
            this.Change.UseVisualStyleBackColor = true;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(977, 397);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(106, 50);
            this.Save.TabIndex = 8;
            this.Save.Text = "Speichern";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1089, 471);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.Bearbeitungstabelle);
            this.Controls.Add(this.Ansichtwechsel);
            this.Controls.Add(this.ICFTabelle);
            this.Controls.Add(this.Ausgabe);
            this.Controls.Add(this.LadeButton);
            this.Controls.Add(this.ICFTree);
            this.Name = "Form1";
            this.Text = "Laden Bearbeiten und Speichern von XML Datei";
            ((System.ComponentModel.ISupportInitialize)(this.ICFTabelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bearbeitungstabelle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ICFTree;
        private System.Windows.Forms.Button LadeButton;
        private System.Windows.Forms.Label Ausgabe;
        private System.Windows.Forms.DataGridView ICFTabelle;
        private System.Windows.Forms.Button Ansichtwechsel;
        private System.Windows.Forms.DataGridView Bearbeitungstabelle;
        private System.Windows.Forms.Button Change;
        private System.Windows.Forms.Button Save;
    }
}

