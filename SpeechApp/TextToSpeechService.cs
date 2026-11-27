using System.Speech.Synthesis;

namespace SpeechApp
{
    // Metni sesli okuyan (Text-to-Speech) sınıf. SpeechService sınıfından türetilmiştir.
    public class TextToSpeechService : SpeechService
    {
        private SpeechSynthesizer synthesizer;

        public TextToSpeechService()
        {
            synthesizer = new SpeechSynthesizer();
            synthesizer.SetOutputToDefaultAudioDevice();
        }

        // Okuma duraklatılmış mı?
        public bool IsPaused
        {
            get { return synthesizer.State == SynthesizerState.Paused; }
        }

        // Metni okumaya başlar. Önceki okuma varsa durdurulur.
        public void Speak(string text)
        {
            Stop();
            synthesizer.SpeakAsync(text);
            isActive = true;
        }

        public void Pause()
        {
            if (synthesizer.State == SynthesizerState.Speaking)
                synthesizer.Pause();
        }

        public void Resume()
        {
            if (synthesizer.State == SynthesizerState.Paused)
                synthesizer.Resume();
        }

        public override void Stop()
        {
            // Duraklatılmış okuma önce devam ettirilmeli, yoksa iptal edilemez.
            if (synthesizer.State == SynthesizerState.Paused)
                synthesizer.Resume();

            synthesizer.SpeakAsyncCancelAll();
            isActive = false;
        }

        // Okuma kendiliğinden bittiyse durumu günceller (Timer içinden çağrılır).
        public void CheckFinished()
        {
            if (isActive && synthesizer.State == SynthesizerState.Ready)
                isActive = false;
        }

        public override string GetStatus()
        {
            if (!isActive)
                return "Okuma: Beklemede";
            if (IsPaused)
                return "Okuma: Duraklatıldı";
            return "Okuma: Metin okunuyor...";
        }

        public void Close()
        {
            Stop();
            synthesizer.Dispose();
        }
    }
}