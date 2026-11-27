namespace SpeechApp
{
    // Metin okuma ve konuşma tanıma servislerinin ortak özelliklerini tutan soyut sınıf.
    public abstract class SpeechService
    {
        protected bool isActive;

        public SpeechService()
        {
            isActive = false;
        }

        // Servis şu an çalışıyor mu? (okuyor / dinliyor)
        public bool IsActive
        {
            get { return isActive; }
        }

        // Arayüzde gösterilecek durum yazısı
        public abstract string GetStatus();

        // Servisin yaptığı işlemi durdurur.
        public abstract void Stop();
    }
}