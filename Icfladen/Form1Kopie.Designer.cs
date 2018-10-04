namespace Icfladen
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
            this.SaveInOldFormat = new System.Windows.Forms.Button();
            this.Ausgabe = new System.Windows.Forms.Label();
            this.ICFTabelle = new System.Windows.Forms.DataGridView();
            this.Ansichtwechsel = new System.Windows.Forms.Button();
            this.Change = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.EdierBox = new System.Windows.Forms.RichTextBox();
            this.FillTree = new System.Windows.Forms.Button();
            this.CSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ICFTabelle)).BeginInit();
            this.SuspendLayout();
            // 
            // ICFTree
            // 
            this.ICFTree.Location = new System.Drawing.Point(28, 20);
            this.ICFTree.Name = "ICFTree";
            this.ICFTree.Size = new System.Drawing.Size(953, 340);
            this.ICFTree.TabIndex = 0;
            this.ICFTree.Visible = false;
            // 
            // SaveInOldFormat
            // 
            this.SaveInOldFormat.Location = new System.Drawing.Point(252, 557);
            this.SaveInOldFormat.Name = "SaveInOldFormat";
            this.SaveInOldFormat.Size = new System.Drawing.Size(106, 44);
            this.SaveInOldFormat.TabIndex = 1;
            this.SaveInOldFormat.Text = "Speichern in altem Format";
            this.SaveInOldFormat.UseVisualStyleBackColor = true;
            this.SaveInOldFormat.Click += new System.EventHandler(this.LadeButton_Click);
            // 
            // Ausgabe
            // 
            this.Ausgabe.AutoSize = true;
            this.Ausgabe.Location = new System.Drawing.Point(373, 501);
            this.Ausgabe.Name = "Ausgabe";
            this.Ausgabe.Size = new System.Drawing.Size(35, 13);
            this.Ausgabe.TabIndex = 3;
            this.Ausgabe.Text = "label1";
            // 
            // ICFTabelle
            // 
            this.ICFTabelle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ICFTabelle.Location = new System.Drawing.Point(20, 20);
            this.ICFTabelle.Name = "ICFTabelle";
            this.ICFTabelle.Size = new System.Drawing.Size(1160, 255);
            this.ICFTabelle.TabIndex = 4;
            this.ICFTabelle.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ICFTabelle_CellValueChanged);
            this.ICFTabelle.CurrentCellChanged += new System.EventHandler(this.ICFTabelle_CurrentCellChanged);
            // 
            // Ansichtwechsel
            // 
            this.Ansichtwechsel.Location = new System.Drawing.Point(28, 557);
            this.Ansichtwechsel.Name = "Ansichtwechsel";
            this.Ansichtwechsel.Size = new System.Drawing.Size(106, 44);
            this.Ansichtwechsel.TabIndex = 5;
            this.Ansichtwechsel.Text = "Tabelle oder Tree";
            this.Ansichtwechsel.UseVisualStyleBackColor = true;
            this.Ansichtwechsel.Click += new System.EventHandler(this.Ansichtwechsel_Click);
            // 
            // Change
            // 
            this.Change.Location = new System.Drawing.Point(28, 501);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(106, 47);
            this.Change.TabIndex = 7;
            this.Change.Text = "Änderungen Übernehmen";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(140, 557);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(106, 45);
            this.Save.TabIndex = 8;
            this.Save.Text = "Speichern";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // EdierBox
            // 
            this.EdierBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EdierBox.Location = new System.Drawing.Point(20, 303);
            this.EdierBox.Name = "EdierBox";
            this.EdierBox.Size = new System.Drawing.Size(1160, 189);
            this.EdierBox.TabIndex = 9;
            this.EdierBox.Text = "";
            // 
            // FillTree
            // 
            this.FillTree.Location = new System.Drawing.Point(866, 557);
            this.FillTree.Name = "FillTree";
            this.FillTree.Size = new System.Drawing.Size(115, 45);
            this.FillTree.TabIndex = 10;
            this.FillTree.Text = "Strukturelle Fehler korrigieren";
            this.FillTree.UseVisualStyleBackColor = true;
            this.FillTree.Click += new System.EventHandler(this.FillTree_Click);
            // 
            // CSV
            // 
            this.CSV.Location = new System.Drawing.Point(439, 557);
            this.CSV.Name = "CSV";
            this.CSV.Size = new System.Drawing.Size(110, 40);
            this.CSV.TabIndex = 11;
            this.CSV.Text = "Zeige CSVTabelle";
            this.CSV.UseVisualStyleBackColor = true;
            this.CSV.Click += new System.EventHandler(this.CSV_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1188, 611);
            this.Controls.Add(this.CSV);
            this.Controls.Add(this.FillTree);
            this.Controls.Add(this.EdierBox);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.Ansichtwechsel);
            this.Controls.Add(this.ICFTabelle);
            this.Controls.Add(this.Ausgabe);
            this.Controls.Add(this.SaveInOldFormat);
            this.Controls.Add(this.ICFTree);
            this.Name = "Form1";
            this.Text = "Laden Bearbeiten und Speichern von XML Datei";
            ((System.ComponentModel.ISupportInitialize)(this.ICFTabelle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ICFTree;
        private System.Windows.Forms.Button SaveInOldFormat;
        private System.Windows.Forms.Label Ausgabe;
        private System.Windows.Forms.DataGridView ICFTabelle;
        private System.Windows.Forms.Button Ansichtwechsel;
        private System.Windows.Forms.Button Change;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.RichTextBox EdierBox;
        private System.Windows.Forms.Button FillTree;
        private System.Windows.Forms.Button CSV;
    }
}

