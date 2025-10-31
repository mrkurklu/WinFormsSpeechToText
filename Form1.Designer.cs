namespace WinFormsSpeechToText // Projenin adı neyse o olmalı
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Bu 4 kontrolü oluşturuyoruz
            this.btnBaslat = new System.Windows.Forms.Button();
            this.btnDurdur = new System.Windows.Forms.Button();
            this.txtSonuc = new System.Windows.Forms.TextBox();
            this.lblDurum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBaslat
            // 
            this.btnBaslat.Location = new System.Drawing.Point(12, 12);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(112, 23);
            this.btnBaslat.TabIndex = 0;
            this.btnBaslat.Text = "Dinlemeye Başla";
            this.btnBaslat.UseVisualStyleBackColor = true;
            // Bu satır, 'btnBaslat' butonunu Form1.cs'teki 'btnBaslat_Click' metoduna bağlar
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // btnDurdur
            // 
            this.btnDurdur.Location = new System.Drawing.Point(130, 12);
            this.btnDurdur.Name = "btnDurdur";
            this.btnDurdur.Size = new System.Drawing.Size(112, 23);
            this.btnDurdur.TabIndex = 1;
            this.btnDurdur.Text = "Durdur";
            this.btnDurdur.UseVisualStyleBackColor = true;
            // Bu satır, 'btnDurdur' butonunu Form1.cs'teki 'btnDurdur_Click' metoduna bağlar
            this.btnDurdur.Click += new System.EventHandler(this.btnDurdur_Click);
            // 
            // txtSonuc
            // 
            this.txtSonuc.Location = new System.Drawing.Point(12, 41);
            this.txtSonuc.Multiline = true;
            this.txtSonuc.Name = "txtSonuc";
            this.txtSonuc.ReadOnly = true;
            this.txtSonuc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSonuc.Size = new System.Drawing.Size(230, 156);
            this.txtSonuc.TabIndex = 2;
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(12, 210);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(41, 15);
            this.lblDurum.TabIndex = 3;
            this.lblDurum.Text = "Hazır.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 240);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.txtSonuc);
            this.Controls.Add(this.btnDurdur);
            this.Controls.Add(this.btnBaslat);
            this.Name = "Form1";
            this.Text = "Speech-to-Text";
            // Bu olaylar Form1.cs'teki metodlara bağlanır
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Bu 4 satır, kontrollerin Form1.cs tarafından tanınmasını sağlar
        private Button btnBaslat;
        private Button btnDurdur;
        private TextBox txtSonuc;
        private Label lblDurum;
    }
}