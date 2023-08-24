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

        public SiparisDetay()
        {}

        public SiparisDetay(int id , int siparisMasterId , SiparisMaster sMaster , Urun urun , int UrunId , double adet , double fiyat)
        {
            ID = id;
            SiparisMasterId = siparisMasterId;
            SiparisMaster = sMaster;
            Urun = urun;
            this.UrunId = UrunId;
            Adet = adet;
            Fiyat = fiyat;
        }
    }
}