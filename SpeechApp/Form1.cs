using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpeechApp
{
    public partial class Form1 : Form
    {
        private TextToSpeechService tts;
        private SpeechToTextService stt;

        public Form1()
        {
            InitializeComponent();

            stt = new SpeechToTextService();
            try
            {
                tts = new TextToSpeechService();
            }
            catch (Exception ex)
            {
                tts = null;
                MessageBox.Show("Ses çıkışı başlatılamadı, metin okuma kullanılamayacak.\n" + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateScreen();
            statusTimer.Start();
        }

        // ---------- Text-to-Speech (Metni Sesli Okuma) ----------

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            if (tts == null)
                return;

            string text = txtTts.Text.Trim();
            if (text == "")
            {
                MessageBox.Show("Lütfen okunacak bir metin yazın.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                tts.Speak(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Metin okunamadı.\n" + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateScreen();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (tts.IsPaused)
                tts.Resume();
            else
                tts.Pause();
            UpdateScreen();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tts.Stop();
            UpdateScreen();
        }

        private void btnClearTts_Click(object sender, EventArgs e)
        {
            if (tts != null)
                tts.Stop();
            txtTts.Text = "";
            UpdateScreen();
        }

        // ---------- Speech-to-Text (Konuşmayı Metne Çevirme) ----------

        private void btnListen_Click(object sender, EventArgs e)
        {
            try
            {
                stt.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Konuşma tanıma başlatılamadı. Mikrofonun bağlı olduğundan emin olun.\n\n" + ex.Message,
                    "Mikrofon / Konuşma Servisi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateScreen();
        }

        private void btnStopListen_Click(object sender, EventArgs e)
        {
            stt.Stop();
            UpdateScreen();
        }

        private void btnClearStt_Click(object sender, EventArgs e)
        {
            txtStt.Text = "";
        }

        // ---------- Ortak ----------

        // Timer her çalıştığında: okuma bitti mi kontrol edilir, tanınan yeni cümleler yazılır.
        private void statusTimer_Tick(object sender, EventArgs e)
        {
            if (tts != null)
                tts.CheckFinished();

            string result = stt.GetNextResult();
            while (result != null)
            {
                txtStt.Text = txtStt.Text + result + " ";
                result = stt.GetNextResult();
            }

            UpdateScreen();
        }

        // Butonları ve durum yazılarını o anki duruma göre günceller.
        private void UpdateScreen()
        {
            bool speaking = tts != null && tts.IsActive;
            bool listening = stt.IsActive;

            if (tts == null)
                lblTtsStatus.Text = "Okuma: Kullanılamıyor";
            else
                lblTtsStatus.Text = tts.GetStatus();
            lblSttStatus.Text = stt.GetStatus();

            btnSpeak.Enabled = tts != null;
            btnPause.Enabled = speaking;
            btnStop.Enabled = speaking;
            if (speaking && tts.IsPaused)
                btnPause.Text = "Devam Et";
            else
                btnPause.Text = "Duraklat";

            btnListen.Enabled = !listening;
            btnStopListen.Enabled = listening;

            // Üstteki büyük gösterge: hangi işlem aktif?
            if (speaking && listening)
                lblActive.Text = "Aktif işlem: Metin okunuyor + Mikrofon dinleniyor";
            else if (speaking)
                lblActive.Text = "Aktif işlem: Metin okunuyor (Text-to-Speech)";
            else if (listening)
                lblActive.Text = "Aktif işlem: Mikrofon dinleniyor (Speech-to-Text)";
            else
                lblActive.Text = "Aktif işlem: Yok";

            if (speaking || listening)
                lblActive.BackColor = Color.ForestGreen;
            else
                lblActive.BackColor = Color.DimGray;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            statusTimer.Stop();
            if (tts != null)
                tts.Close();
            stt.Close();
        }
    }
}