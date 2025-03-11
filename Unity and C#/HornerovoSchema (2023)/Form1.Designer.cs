namespace HornerovoSchema
{
    partial class HornerovoSchema
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dvojabut = new System.Windows.Forms.Button();
            this.osmbutt = new System.Windows.Forms.Button();
            this.desetbutt = new System.Windows.Forms.Button();
            this.sestnactbutt = new System.Windows.Forms.Button();
            this.dvatextbox = new System.Windows.Forms.TextBox();
            this.osmtextbox = new System.Windows.Forms.TextBox();
            this.desettextbox = new System.Windows.Forms.TextBox();
            this.sestnacttextbox = new System.Windows.Forms.TextBox();
            this.dvacheck = new System.Windows.Forms.CheckBox();
            this.osmcheck = new System.Windows.Forms.CheckBox();
            this.sestnactcheck = new System.Windows.Forms.CheckBox();
            this.nastavenigroupbox = new System.Windows.Forms.GroupBox();
            this.prevodgroupbox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kontrolasoustav = new System.Windows.Forms.Timer(this.components);
            this.progressbar = new System.Windows.Forms.ProgressBar();
            this.konecbutt = new System.Windows.Forms.Button();
            this.KontrolaCheckboxu = new System.Windows.Forms.Timer(this.components);
            this.nastavenigroupbox.SuspendLayout();
            this.prevodgroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // dvojabut
            // 
            this.dvojabut.Location = new System.Drawing.Point(6, 19);
            this.dvojabut.Name = "dvojabut";
            this.dvojabut.Size = new System.Drawing.Size(75, 23);
            this.dvojabut.TabIndex = 1;
            this.dvojabut.Text = "Dvojkova";
            this.dvojabut.UseVisualStyleBackColor = true;
            this.dvojabut.Click += new System.EventHandler(this.dvojabut_Click);
            // 
            // osmbutt
            // 
            this.osmbutt.Location = new System.Drawing.Point(6, 49);
            this.osmbutt.Name = "osmbutt";
            this.osmbutt.Size = new System.Drawing.Size(75, 23);
            this.osmbutt.TabIndex = 2;
            this.osmbutt.Text = "Osmickova";
            this.osmbutt.UseVisualStyleBackColor = true;
            this.osmbutt.Click += new System.EventHandler(this.osmbutt_Click);
            // 
            // desetbutt
            // 
            this.desetbutt.Location = new System.Drawing.Point(6, 79);
            this.desetbutt.Name = "desetbutt";
            this.desetbutt.Size = new System.Drawing.Size(75, 23);
            this.desetbutt.TabIndex = 3;
            this.desetbutt.Text = "Desitkova";
            this.desetbutt.UseVisualStyleBackColor = true;
            this.desetbutt.Click += new System.EventHandler(this.desetbutt_Click);
            // 
            // sestnactbutt
            // 
            this.sestnactbutt.Location = new System.Drawing.Point(6, 108);
            this.sestnactbutt.Name = "sestnactbutt";
            this.sestnactbutt.Size = new System.Drawing.Size(75, 23);
            this.sestnactbutt.TabIndex = 4;
            this.sestnactbutt.Text = "Sestnactkova";
            this.sestnactbutt.UseVisualStyleBackColor = true;
            this.sestnactbutt.Click += new System.EventHandler(this.sestnactbutt_Click);
            // 
            // dvatextbox
            // 
            this.dvatextbox.Location = new System.Drawing.Point(102, 22);
            this.dvatextbox.Name = "dvatextbox";
            this.dvatextbox.Size = new System.Drawing.Size(100, 20);
            this.dvatextbox.TabIndex = 5;
            // 
            // osmtextbox
            // 
            this.osmtextbox.Location = new System.Drawing.Point(102, 52);
            this.osmtextbox.Name = "osmtextbox";
            this.osmtextbox.Size = new System.Drawing.Size(100, 20);
            this.osmtextbox.TabIndex = 6;
            // 
            // desettextbox
            // 
            this.desettextbox.Location = new System.Drawing.Point(102, 82);
            this.desettextbox.Name = "desettextbox";
            this.desettextbox.Size = new System.Drawing.Size(100, 20);
            this.desettextbox.TabIndex = 7;
            // 
            // sestnacttextbox
            // 
            this.sestnacttextbox.Location = new System.Drawing.Point(102, 111);
            this.sestnacttextbox.Name = "sestnacttextbox";
            this.sestnacttextbox.Size = new System.Drawing.Size(100, 20);
            this.sestnacttextbox.TabIndex = 8;
            // 
            // dvacheck
            // 
            this.dvacheck.AutoSize = true;
            this.dvacheck.Location = new System.Drawing.Point(6, 46);
            this.dvacheck.Name = "dvacheck";
            this.dvacheck.Size = new System.Drawing.Size(72, 17);
            this.dvacheck.TabIndex = 9;
            this.dvacheck.Text = "Dvojkova";
            this.dvacheck.UseVisualStyleBackColor = true;
            this.dvacheck.Click += new System.EventHandler(this.dvacheck_Click);
            // 
            // osmcheck
            // 
            this.osmcheck.AutoSize = true;
            this.osmcheck.Location = new System.Drawing.Point(6, 69);
            this.osmcheck.Name = "osmcheck";
            this.osmcheck.Size = new System.Drawing.Size(79, 17);
            this.osmcheck.TabIndex = 10;
            this.osmcheck.Text = "Osmickova";
            this.osmcheck.UseVisualStyleBackColor = true;
            this.osmcheck.Click += new System.EventHandler(this.osmcheck_Click);
            // 
            // sestnactcheck
            // 
            this.sestnactcheck.AutoSize = true;
            this.sestnactcheck.Location = new System.Drawing.Point(6, 92);
            this.sestnactcheck.Name = "sestnactcheck";
            this.sestnactcheck.Size = new System.Drawing.Size(89, 17);
            this.sestnactcheck.TabIndex = 11;
            this.sestnactcheck.Text = "Sesnactkova";
            this.sestnactcheck.UseVisualStyleBackColor = true;
            this.sestnactcheck.Click += new System.EventHandler(this.sestnactcheck_Click);
            // 
            // nastavenigroupbox
            // 
            this.nastavenigroupbox.Controls.Add(this.textBox1);
            this.nastavenigroupbox.Controls.Add(this.dvacheck);
            this.nastavenigroupbox.Controls.Add(this.sestnactcheck);
            this.nastavenigroupbox.Controls.Add(this.osmcheck);
            this.nastavenigroupbox.Location = new System.Drawing.Point(12, 76);
            this.nastavenigroupbox.Name = "nastavenigroupbox";
            this.nastavenigroupbox.Size = new System.Drawing.Size(202, 183);
            this.nastavenigroupbox.TabIndex = 12;
            this.nastavenigroupbox.TabStop = false;
            this.nastavenigroupbox.Text = "Nastaveni";
            // 
            // prevodgroupbox
            // 
            this.prevodgroupbox.Controls.Add(this.dvojabut);
            this.prevodgroupbox.Controls.Add(this.osmbutt);
            this.prevodgroupbox.Controls.Add(this.desetbutt);
            this.prevodgroupbox.Controls.Add(this.sestnactbutt);
            this.prevodgroupbox.Controls.Add(this.dvatextbox);
            this.prevodgroupbox.Controls.Add(this.sestnacttextbox);
            this.prevodgroupbox.Controls.Add(this.osmtextbox);
            this.prevodgroupbox.Controls.Add(this.desettextbox);
            this.prevodgroupbox.Location = new System.Drawing.Point(245, 75);
            this.prevodgroupbox.Name = "prevodgroupbox";
            this.prevodgroupbox.Size = new System.Drawing.Size(208, 183);
            this.prevodgroupbox.TabIndex = 0;
            this.prevodgroupbox.TabStop = false;
            this.prevodgroupbox.Text = "Prevod";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(105, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Prevod mezi soustavami";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(105, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "(Zakladni soustava je desitkova)";
            // 
            // kontrolasoustav
            // 
            this.kontrolasoustav.Enabled = true;
            this.kontrolasoustav.Interval = 50;
            this.kontrolasoustav.Tick += new System.EventHandler(this.kontrolasoustav_Tick);
            // 
            // progressbar
            // 
            this.progressbar.Location = new System.Drawing.Point(12, 304);
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(441, 23);
            this.progressbar.TabIndex = 15;
            // 
            // konecbutt
            // 
            this.konecbutt.Location = new System.Drawing.Point(191, 275);
            this.konecbutt.Name = "konecbutt";
            this.konecbutt.Size = new System.Drawing.Size(75, 23);
            this.konecbutt.TabIndex = 16;
            this.konecbutt.Text = "Ukoncit";
            this.konecbutt.UseVisualStyleBackColor = true;
            this.konecbutt.Click += new System.EventHandler(this.konecbutt_Click);
            // 
            // KontrolaCheckboxu
            // 
            this.KontrolaCheckboxu.Enabled = true;
            // 
            // HornerovoSchema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 332);
            this.Controls.Add(this.konecbutt);
            this.Controls.Add(this.progressbar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prevodgroupbox);
            this.Controls.Add(this.nastavenigroupbox);
            this.Name = "HornerovoSchema";
            this.Text = "HornerovoSchema";
            this.nastavenigroupbox.ResumeLayout(false);
            this.nastavenigroupbox.PerformLayout();
            this.prevodgroupbox.ResumeLayout(false);
            this.prevodgroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button dvojabut;
        private System.Windows.Forms.Button osmbutt;
        private System.Windows.Forms.Button desetbutt;
        private System.Windows.Forms.Button sestnactbutt;
        private System.Windows.Forms.TextBox dvatextbox;
        private System.Windows.Forms.TextBox osmtextbox;
        private System.Windows.Forms.TextBox desettextbox;
        private System.Windows.Forms.TextBox sestnacttextbox;
        private System.Windows.Forms.CheckBox dvacheck;
        private System.Windows.Forms.CheckBox osmcheck;
        private System.Windows.Forms.CheckBox sestnactcheck;
        private System.Windows.Forms.GroupBox nastavenigroupbox;
        private System.Windows.Forms.GroupBox prevodgroupbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer kontrolasoustav;
        private System.Windows.Forms.ProgressBar progressbar;
        private System.Windows.Forms.Button konecbutt;
        private System.Windows.Forms.Timer KontrolaCheckboxu;
    }
}

