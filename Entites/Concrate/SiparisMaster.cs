using Entites.Abstract;

namespace Entites.Concrate
{
    public class SiparisMaster : BaseEntity
    {
        public int MasaId { get; set; }
        public Masa Masa { get; set; }

        public ICollection<SiparisDetay>? SiparisDetay { get; set; }
        public double? ToplamTutar { get; set; }

        public bool IsActive { get; set; } = true;
        
    }
}