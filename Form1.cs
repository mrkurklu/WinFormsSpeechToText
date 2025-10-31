using System;
using System.Globalization;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace WinFormsSpeechToText // Buras� projenin ad�, dokunma
{
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine recognizer;

        // Buras� formun 'constructor'� (yap�c� metodu)
        public Form1()
        {
            InitializeComponent(); // Bu sat�r Form1.Designer.cs'teki g�rsel ayarlar� �a��r�r
        }

        // Form ilk y�klendi�inde �al��acak kod
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

                // Olaylar� (Events) ba�la
                recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
                recognizer.SpeechHypothesized += Recognizer_SpeechHypothesized;
                recognizer.RecognizeCompleted += Recognizer_RecognizeCompleted;

                lblDurum.Text = "Haz�r. 'Ba�lat' tu�una bas�n.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\n\n'tr-TR' konu�ma paketinin y�kl� oldu�undan emin olun.", "Ba�latma Hatas�");
                btnBaslat.Enabled = false;
            }
        }

        // btnBaslat butonuna t�kland���nda
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
                    MessageBox.Show($"Tan�ma ba�lat�lamad�: {ex.Message}");
                }
            }
        }

        // btnDurdur butonuna t�kland���nda
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

        // Konu�ma tan�nd���nda
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

        // Konu�ma tahmin edildi�inde (opsiyonel)
        private void Recognizer_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            // Gerekirse kullan�l�r
        }

        // Tan�ma durdu�unda
        private void Recognizer_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                lblDurum.Text = "Durduruldu.";
                btnBaslat.Enabled = true;
                btnDurdur.Enabled = false;
            }));
        }

        // Form kapand���nda
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (recognizer != null)
            {
                recognizer.Dispose();
            }
        }
    }
}