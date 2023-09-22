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
            Onay_Bekliyor = 1,
            Onaylandı = 2,
            Hazırlanıyor = 3,
            Teslime_Hazır = 4,
            Iptal = 5,
            Teslim_Edildi = 6
        }
        
    }
}