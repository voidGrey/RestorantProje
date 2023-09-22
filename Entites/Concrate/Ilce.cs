namespace Entites.Concrate
{
    public class Ilce
    {
        public int Id { get; set; }
        public int? SehirId { get; set; }
        public Sehir? Sehir { get; set; }
        public string IlceAdi { get; set; }
    }
}