using Entites.Abstract;

namespace Entites.Concrate
{
    public class Urun : BaseEntity
    {
        public string? UrunAdi { get; set; }
        public string? UrunAciklama { get; set; }
        public string? FotografLink { get; set; }
        public double Fiyat { get; set; }

        //Kategori ile ilişki

        public int KategoriID { get; set; } 
        public Kategori Kategori { get; set; }
    }
}