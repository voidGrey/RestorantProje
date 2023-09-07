using Entites.Abstract;

namespace Entites.Concrate
{

   public enum KasaHareketTipi:byte
    {
        Giris=1,
        Cikis=2,
        GunSonu=3,
        Devir=4
    }

    public class KasaHareket:BaseEntity
    {
        public int KasaId { get; set; }
        public Kasa Kasa { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public double Tutar { get; set; }

        public KasaHareketTipi HareketTipi { get; set; }


    }
}