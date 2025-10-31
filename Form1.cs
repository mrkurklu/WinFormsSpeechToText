using System;
using System.Globalization;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace WinFormsSpeechToText // Burasý projenin adý, dokunma
{
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine recognizer;

        // Burasý formun 'constructor'ý (yapýcý metodu)
        public Form1()
        {
            InitializeComponent(); // Bu satýr Form1.Designer.cs'teki görsel ayarlarý çaðýrýr
        }

        // Form ilk yüklendiðinde çalýþacak kod
        private void Form1_Load(object sender, EventArgs e)
        {
            btnBaslat.Enabled = true;
            btnDurdur.Enabled = false;

            try
            {
                CultureInfo culture = new CultureInfo("tr-TR");
                recognizer = new SpeechRecognitionEngine(culture);
                recognizer.LoadGrammar(new DictationGrammar());
                recognizer.SetInputToDefaultAudioDevice();

                // Olaylarý (Events) baðla
                recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
                recognizer.SpeechHypothesized += Recognizer_SpeechHypothesized;
                recognizer.RecognizeCompleted += Recognizer_RecognizeCompleted;

                lblDurum.Text = "Hazýr. 'Baþlat' tuþuna basýn.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\n\n'tr-TR' konuþma paketinin yüklü olduðundan emin olun.", "Baþlatma Hatasý");
                btnBaslat.Enabled = false;
            }
        }

        // btnBaslat butonuna týklandýðýnda
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            if (recognizer != null)
            {
                try
                {
                    recognizer.RecognizeAsync(RecognizeMode.Multiple);
                    lblDurum.Text = "Dinleniyor...";
                    btnBaslat.Enabled = false;
                    btnDurdur.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Tanýma baþlatýlamadý: {ex.Message}");
                }
            }
        }

        // btnDurdur butonuna týklandýðýnda
        private void btnDurdur_Click(object sender, EventArgs e)
        {
            if (recognizer != null)
            {
                recognizer.RecognizeAsyncStop();
                lblDurum.Text = "Durduruldu.";
                btnBaslat.Enabled = true;
                btnDurdur.Enabled = false;
            }
        }

        // Konuþma tanýndýðýnda
        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result != null)
            {
                this.Invoke(new Action(() =>
                {
                    txtSonuc.AppendText(e.Result.Text + "\r\n");
                }));
            }
        }

        // Konuþma tahmin edildiðinde (opsiyonel)
        private void Recognizer_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            // Gerekirse kullanýlýr
        }

        // Tanýma durduðunda
        private void Recognizer_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                lblDurum.Text = "Durduruldu.";
                btnBaslat.Enabled = true;
                btnDurdur.Enabled = false;
            }));
        }

        // Form kapandýðýnda
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (recognizer != null)
            {
                recognizer.Dispose();
            }
        }
    }
}