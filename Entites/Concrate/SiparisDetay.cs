using Entites.Abstract;

namespace Entites.Concrate
{
    public class SiparisDetay : BaseEntity
    {
        public int SiparisMasterId { get; set; }
        public SiparisMaster SiparisMaster { get; set; }
        public Urun Urun { get; set; }
        public int UrunId { get; set; }

        public double Adet { get; set; }
        public double Fiyat { get; set; }
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
        public SiparisDetay()
        {}

        public SiparisDetay(int siparisMasterId , SiparisMaster sMaster , Urun urun , int UrunId , double adet , double fiyat)
        {
            SiparisMasterId = siparisMasterId;
            SiparisMaster = sMaster;
            Urun = urun;
            this.UrunId = UrunId;
            Adet = adet;
            Fiyat = fiyat;
        }
    }
}