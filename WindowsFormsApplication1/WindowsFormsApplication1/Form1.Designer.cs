namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.postavke = new System.Windows.Forms.ListView();
            this.znesek = new System.Windows.Forms.Label();
            this.stevilka = new System.Windows.Forms.TextBox();
            this.novracun = new System.Windows.Forms.Button();
            this.dodajanje = new System.Windows.Forms.Button();
            this.izdelki = new System.Windows.Forms.ComboBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // postavke
            // 
            this.postavke.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.postavke.Location = new System.Drawing.Point(12, 71);
            this.postavke.Name = "postavke";
            this.postavke.Size = new System.Drawing.Size(643, 279);
            this.postavke.TabIndex = 0;
            this.postavke.UseCompatibleStateImageBehavior = false;
            this.postavke.View = System.Windows.Forms.View.Details;
            // 
            // znesek
            // 
            this.znesek.AutoSize = true;
            this.znesek.Location = new System.Drawing.Point(524, 365);
            this.znesek.Name = "znesek";
            this.znesek.Size = new System.Drawing.Size(41, 13);
            this.znesek.TabIndex = 1;
            this.znesek.Text = "znesek";
            // 
            // stevilka
            // 
            this.stevilka.Location = new System.Drawing.Point(41, 13);
            this.stevilka.Name = "stevilka";
            this.stevilka.Size = new System.Drawing.Size(100, 20);
            this.stevilka.TabIndex = 2;
            // 
            // novracun
            // 
            this.novracun.Location = new System.Drawing.Point(580, 13);
            this.novracun.Name = "novracun";
            this.novracun.Size = new System.Drawing.Size(75, 23);
            this.novracun.TabIndex = 3;
            this.novracun.Text = "novracun";
            this.novracun.UseVisualStyleBackColor = true;
            this.novracun.Click += new System.EventHandler(this.novracun_Click);
            // 
            // dodajanje
            // 
            this.dodajanje.Location = new System.Drawing.Point(580, 42);
            this.dodajanje.Name = "dodajanje";
            this.dodajanje.Size = new System.Drawing.Size(75, 23);
            this.dodajanje.TabIndex = 4;
            this.dodajanje.Text = "dodajanje";
            this.dodajanje.UseVisualStyleBackColor = true;
            this.dodajanje.Click += new System.EventHandler(this.dodajanje_Click);
            // 
            // izdelki
            // 
            this.izdelki.FormattingEnabled = true;
            this.izdelki.Location = new System.Drawing.Point(224, 42);
            this.izdelki.Name = "izdelki";
            this.izdelki.Size = new System.Drawing.Size(350, 21);
            this.izdelki.TabIndex = 5;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Izdelek";
            this.columnHeader1.Width = 322;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Neto cena";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 134;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Bruto cena";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 146;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 404);
            this.Controls.Add(this.izdelki);
            this.Controls.Add(this.dodajanje);
            this.Controls.Add(this.novracun);
            this.Controls.Add(this.stevilka);
            this.Controls.Add(this.znesek);
            this.Controls.Add(this.postavke);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView postavke;
        private System.Windows.Forms.Label znesek;
        private System.Windows.Forms.TextBox stevilka;
        private System.Windows.Forms.Button novracun;
        private System.Windows.Forms.Button dodajanje;
        private System.Windows.Forms.ComboBox izdelki;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

