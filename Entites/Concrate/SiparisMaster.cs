using Entites.Abstract;

namespace Entites.Concrate
{
    public class SiparisMaster : BaseEntity
    {
        public int? MasaId { get; set; }
        public Masa Masa { get; set; }

        public ICollection<SiparisDetay>? SiparisDetay { get; set; }
        public double? ToplamTutar { get; set; }
        public bool IsActive { get; set; } = true;
        public Status status { get; set; } = (Status)1;

        public enum Status
        {
            Onaylanmadı = 1,
            Hazırlanıyor = 2,
            TeslimeHazır = 3,
            Iptal = 4,
            TeslimEdildi = 5,
        }
        
    }
}