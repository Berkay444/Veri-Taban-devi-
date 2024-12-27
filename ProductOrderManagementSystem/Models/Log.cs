namespace ProductOrderManagementSystem.Models
{
    
    public class Log
    {
        // Benzersiz bir kimlik için ID
        public int Id { get; set; }

        // Log mesajı
        public string Message { get; set; }

        // Log seviyesini belirten alan (ör. Bilgi, Uyarı, Hata)
        public string LogLevel { get; set; }

        // Log oluşturulma tarihi ve saati
        public DateTime Timestamp { get; set; }

        // Opsiyonel: Hangi kullanıcı veya sistem tarafından oluşturulduğu
        public string User { get; set; }

        // Opsiyonel: Hangi kaynağa veya işleve ait olduğu
        public string Source { get; set; }
    }

}
