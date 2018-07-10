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
            this.LadeButton = new System.Windows.Forms.Button();
            this.TreeButton = new System.Windows.Forms.Button();
            this.Ausgabe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ICFTree
            // 
            this.ICFTree.Location = new System.Drawing.Point(28, 20);
            this.ICFTree.Name = "ICFTree";
            this.ICFTree.Size = new System.Drawing.Size(533, 409);
            this.ICFTree.TabIndex = 0;
            // 
            // LadeButton
            // 
            this.LadeButton.Location = new System.Drawing.Point(673, 384);
            this.LadeButton.Name = "LadeButton";
            this.LadeButton.Size = new System.Drawing.Size(106, 44);
            this.LadeButton.TabIndex = 1;
            this.LadeButton.Text = "Lade Datei";
            this.LadeButton.UseVisualStyleBackColor = true;
            this.LadeButton.Click += new System.EventHandler(this.LadeButton_Click);
            // 
            // TreeButton
            // 
            this.TreeButton.Location = new System.Drawing.Point(673, 320);
            this.TreeButton.Name = "TreeButton";
            this.TreeButton.Size = new System.Drawing.Size(105, 46);
            this.TreeButton.TabIndex = 2;
            this.TreeButton.Text = "button1";
            this.TreeButton.UseVisualStyleBackColor = true;
            this.TreeButton.Click += new System.EventHandler(this.TreeButton_Click_1);
            // 
            // Ausgabe
            // 
            this.Ausgabe.AutoSize = true;
            this.Ausgabe.Location = new System.Drawing.Point(587, 43);
            this.Ausgabe.Name = "Ausgabe";
            this.Ausgabe.Size = new System.Drawing.Size(35, 13);
            this.Ausgabe.TabIndex = 3;
            this.Ausgabe.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Ausgabe);
            this.Controls.Add(this.TreeButton);
            this.Controls.Add(this.LadeButton);
            this.Controls.Add(this.ICFTree);
            this.Name = "Form1";
            this.Text = "Versuch Laden von XML Datei";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ICFTree;
        private System.Windows.Forms.Button LadeButton;
        private System.Windows.Forms.Button TreeButton;
        private System.Windows.Forms.Label Ausgabe;
    }
}

