using Entites.Abstract;

namespace Entites.Concrate
{
    public class Masa : BaseEntity
    {
        public int MasaID { get; set; }
        public virtual List<Siparis> Siparisler { get; set; }
    }
}