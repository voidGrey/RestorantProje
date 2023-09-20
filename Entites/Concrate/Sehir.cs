namespace Entites.Concrate
{
    public class Sehir 
    {
        public int Id { get; set; }
        public string SehirAdi { get; set; }
        public string? PlakaKodu { get; set; }

        public ICollection<Ilce>? Ilceler { get; set; }
    }
}