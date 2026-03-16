namespace personelkayitsistemi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelheader = new System.Windows.Forms.Panel();
            this.labelbaslik = new System.Windows.Forms.Label();
            this.gruppersonel = new System.Windows.Forms.GroupBox();
            this.btnGoz = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.btngiris = new System.Windows.Forms.Button();
            this.btntemizle = new System.Windows.Forms.Button();
            this.grupyazilim = new System.Windows.Forms.GroupBox();
            this.listexe = new System.Windows.Forms.ListBox();
            this.btnexecalistir = new System.Windows.Forms.Button();
            this.panelicerik = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelheader.SuspendLayout();
            this.gruppersonel.SuspendLayout();
            this.grupyazilim.SuspendLayout();
            this.panelicerik.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(79)))), ((int)(((byte)(107)))));
            this.panelheader.Controls.Add(this.labelbaslik);
            this.panelheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelheader.Location = new System.Drawing.Point(0, 0);
            this.panelheader.Name = "panelheader";
            this.panelheader.Size = new System.Drawing.Size(1460, 100);
            this.panelheader.TabIndex = 0;
            // 
            // labelbaslik
            // 
            this.labelbaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelbaslik.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelbaslik.ForeColor = System.Drawing.Color.White;
            this.labelbaslik.Location = new System.Drawing.Point(0, 0);
            this.labelbaslik.Name = "labelbaslik";
            this.labelbaslik.Size = new System.Drawing.Size(1460, 100);
            this.labelbaslik.TabIndex = 0;
            this.labelbaslik.Text = "PERSONEL KAYIT SİSTEMİ";
            this.labelbaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gruppersonel
            // 
            this.gruppersonel.Controls.Add(this.btnGoz);
            this.gruppersonel.Controls.Add(this.comboBox1);
            this.gruppersonel.Controls.Add(this.textBox5);
            this.gruppersonel.Controls.Add(this.textBox4);
            this.gruppersonel.Controls.Add(this.textBox3);
            this.gruppersonel.Controls.Add(this.textBox2);
            this.gruppersonel.Controls.Add(this.textBox1);
            this.gruppersonel.Controls.Add(this.label6);
            this.gruppersonel.Controls.Add(this.label5);
            this.gruppersonel.Controls.Add(this.label4);
            this.gruppersonel.Controls.Add(this.label3);
            this.gruppersonel.Controls.Add(this.label2);
            this.gruppersonel.Controls.Add(this.label1);
            this.gruppersonel.Location = new System.Drawing.Point(15, 19);
            this.gruppersonel.Name = "gruppersonel";
            this.gruppersonel.Size = new System.Drawing.Size(452, 334);
            this.gruppersonel.TabIndex = 1;
            this.gruppersonel.TabStop = false;
            this.gruppersonel.Text = "PERSONEL BİLGİLERİ";
            // 
            // btnGoz
            // 
            this.btnGoz.Location = new System.Drawing.Point(367, 196);
            this.btnGoz.Name = "btnGoz";
            this.btnGoz.Size = new System.Drawing.Size(28, 22);
            this.btnGoz.TabIndex = 9;
            this.btnGoz.Text = "👁";
            this.btnGoz.UseVisualStyleBackColor = true;
            this.btnGoz.Click += new System.EventHandler(this.btnGoz_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Bilgisayar Mühendisi",
            "Yazılım Mühendisi",
            "İş Analisti"});
            this.comboBox1.Location = new System.Drawing.Point(181, 241);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(214, 24);
            this.comboBox1.TabIndex = 11;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(181, 196);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(214, 22);
            this.textBox5.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(181, 153);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(214, 22);
            this.textBox4.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(181, 110);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(214, 22);
            this.textBox3.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(181, 68);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(214, 22);
            this.textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(181, 30);
            this.textBox1.MaxLength = 11;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 22);
            this.textBox1.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "DEPARTMAN:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "PAROLA:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "KULLANICI ADI:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "SOYAD:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "AD:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "TC KİMLİK NUMARASI:";
            // 
            // btnkaydet
            // 
            this.btnkaydet.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnkaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkaydet.Location = new System.Drawing.Point(67, 382);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(86, 32);
            this.btnkaydet.TabIndex = 2;
            this.btnkaydet.Text = "KAYDET";
            this.btnkaydet.UseVisualStyleBackColor = false;
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // btngiris
            // 
            this.btngiris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btngiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngiris.ForeColor = System.Drawing.Color.Black;
            this.btngiris.Location = new System.Drawing.Point(181, 241);
            this.btngiris.Name = "btngiris";
            this.btngiris.Size = new System.Drawing.Size(75, 32);
            this.btngiris.TabIndex = 3;
            this.btngiris.Text = "GİRİŞ";
            this.btngiris.UseVisualStyleBackColor = false;
            this.btngiris.Click += new System.EventHandler(this.btngiris_Click);
            // 
            // btntemizle
            // 
            this.btntemizle.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btntemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntemizle.Location = new System.Drawing.Point(196, 382);
            this.btntemizle.Name = "btntemizle";
            this.btntemizle.Size = new System.Drawing.Size(89, 32);
            this.btntemizle.TabIndex = 5;
            this.btntemizle.Text = "TEMİZLE";
            this.btntemizle.UseVisualStyleBackColor = false;
            this.btntemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // grupyazilim
            // 
            this.grupyazilim.Controls.Add(this.listexe);
            this.grupyazilim.Location = new System.Drawing.Point(983, 19);
            this.grupyazilim.Name = "grupyazilim";
            this.grupyazilim.Size = new System.Drawing.Size(376, 334);
            this.grupyazilim.TabIndex = 6;
            this.grupyazilim.TabStop = false;
            this.grupyazilim.Text = "YETKİLİ YAZILIMLAR";
            // 
            // listexe
            // 
            this.listexe.FormattingEnabled = true;
            this.listexe.ItemHeight = 16;
            this.listexe.Items.AddRange(new object[] {
            "cmd.exe",
            "powershell.exe",
            "calc.exe",
            "excel.exe"});
            this.listexe.Location = new System.Drawing.Point(24, 30);
            this.listexe.Name = "listexe";
            this.listexe.Size = new System.Drawing.Size(327, 260);
            this.listexe.TabIndex = 0;
            // 
            // btnexecalistir
            // 
            this.btnexecalistir.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnexecalistir.Location = new System.Drawing.Point(1123, 382);
            this.btnexecalistir.Name = "btnexecalistir";
            this.btnexecalistir.Size = new System.Drawing.Size(75, 37);
            this.btnexecalistir.TabIndex = 7;
            this.btnexecalistir.Text = "EXE AÇ";
            this.btnexecalistir.UseVisualStyleBackColor = false;
            this.btnexecalistir.Click += new System.EventHandler(this.btnExeAc_Click);
            // 
            // panelicerik
            // 
            this.panelicerik.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelicerik.Controls.Add(this.groupBox1);
            this.panelicerik.Controls.Add(this.grupyazilim);
            this.panelicerik.Controls.Add(this.btnexecalistir);
            this.panelicerik.Controls.Add(this.gruppersonel);
            this.panelicerik.Controls.Add(this.btnkaydet);
            this.panelicerik.Controls.Add(this.btntemizle);
            this.panelicerik.Location = new System.Drawing.Point(12, 232);
            this.panelicerik.Name = "panelicerik";
            this.panelicerik.Size = new System.Drawing.Size(1436, 509);
            this.panelicerik.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.btngiris);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(504, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 334);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PERSONEL BİLGİLERİ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 16);
            this.label13.TabIndex = 12;
            this.label13.Text = "KULLANICI ADI:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Bilgisayar Mühendisi",
            "Yazılım Mühendisi",
            "İş Analisti"});
            this.comboBox2.Location = new System.Drawing.Point(181, 116);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(214, 24);
            this.comboBox2.TabIndex = 11;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(181, 68);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(214, 22);
            this.textBox9.TabIndex = 7;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(181, 30);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(214, 22);
            this.textBox10.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "DEPARTMAN:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "PAROLA:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1460, 952);
            this.Controls.Add(this.panelicerik);
            this.Controls.Add(this.panelheader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PERSONEL KAYIT SİSTEMİ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelheader.ResumeLayout(false);
            this.gruppersonel.ResumeLayout(false);
            this.gruppersonel.PerformLayout();
            this.grupyazilim.ResumeLayout(false);
            this.panelicerik.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelheader;
        private System.Windows.Forms.Label labelbaslik;
        private System.Windows.Forms.GroupBox gruppersonel;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.Button btngiris;
        private System.Windows.Forms.Button btntemizle;
        private System.Windows.Forms.GroupBox grupyazilim;
        private System.Windows.Forms.ListBox listexe;
        private System.Windows.Forms.Button btnexecalistir;
        private System.Windows.Forms.Panel panelicerik;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGoz;
    }
}

