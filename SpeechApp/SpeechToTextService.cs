using System;
using System.Collections;
using System.Speech.Recognition;

namespace SpeechApp
{
    // Mikrofondan gelen konuşmayı metne çeviren (Speech-to-Text) sınıf.
    // SpeechService sınıfından türetilmiştir.
    public class SpeechToTextService : SpeechService
    {
        private SpeechRecognitionEngine engine;
        private ArrayList results;     // henüz ekrana yazılmamış tanıma sonuçları
        private string language;

        public SpeechToTextService()
        {
            engine = null;
            results = new ArrayList();
            language = "";
        }

        public string Language
        {
            get { return language; }
        }

        // Dinlemeyi başlatır. Tanıma motoru veya mikrofon yoksa hata fırlatır.
        public void Start()
        {
            if (isActive)
                return;

            if (engine == null)
                CreateEngine();

            // Mikrofon bulunamazsa bu satır hata (exception) verir.
            engine.SetInputToDefaultAudioDevice();
            engine.RecognizeAsync(RecognizeMode.Multiple);
            isActive = true;
        }

        // Bilgisayarda yüklü bir konuşma tanıma motoru bulup hazırlar.
        private void CreateEngine()
        {
            RecognizerInfo selected = null;

            // Bilgisayarda yüklü tanıyıcılardan ilki kullanılır.
            foreach (RecognizerInfo info in SpeechRecognitionEngine.InstalledRecognizers())
            {
                if (selected == null)
                    selected = info;
            }

            if (selected == null)
                throw new Exception("Bu bilgisayarda yüklü bir konuşma tanıma motoru bulunamadı.\n" +
                    "Windows Ayarları > Saat ve dil > Konuşma bölümünden bir konuşma dili ekleyebilirsiniz.");

            engine = new SpeechRecognitionEngine(selected);
            engine.LoadGrammar(new DictationGrammar()); // serbest konuşma (dikte)
            engine.SpeechRecognized += Engine_SpeechRecognized;
            language = selected.Culture.Name;
        }

        // Motor bir cümleyi tanıdığında çalışır; sonuç listeye eklenir.
        private void Engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            results.Add(e.Result.Text);
        }

        // Bekleyen ilk sonucu döndürür, sonuç yoksa null döndürür (Timer içinden çağrılır).
        public string GetNextResult()
        {
            if (results.Count == 0)
                return null;

            string text = (string)results[0];
            results.RemoveAt(0);
            return text;
        }

        public override void Stop()
        {
            if (!isActive)
                return;

            engine.RecognizeAsyncCancel();
            isActive = false;
        }

        public override string GetStatus()
        {
            if (isActive)
                return "Tanıma: Mikrofon dinleniyor... (" + language + ")";
            return "Tanıma: Beklemede";
        }

        public void Close()
        {
            Stop();
            if (engine != null)
                engine.Dispose();
        }
    }
}