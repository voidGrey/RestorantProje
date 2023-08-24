using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrate
{
    public class SiparisDetay:BaseEntity
    {

        public  int SiparisMasterId { get; set; }
        public SiparisMaster SiparisMaster { get; set; }
        public Urun Urun { get; set; }
        public int UrunId { get; set; }

        public double Adet { get; set; }
        public double Fiyat { get; set; }
      

    }
}
