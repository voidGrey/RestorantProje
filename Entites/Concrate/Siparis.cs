using Entites.Abstract;

namespace Entites.Concrate
{
    public class Siparis : BaseEntity
    {
        public List<Urun> Urunler { get; set; }
        public double ToplamFiyat { get; set; }
        public int MasaID { get; set; }
        public virtual Masa Masa { get; set; }
    }
}