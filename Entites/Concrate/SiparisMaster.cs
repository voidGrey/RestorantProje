using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrate
{
    public class SiparisMaster:BaseEntity
    {

      
        public int MasaId { get; set; }
        public Masa Masa { get; set; }

        public ICollection<SiparisDetay>? SiparisDetay { get; set; }
        public double? ToplamTutar { get; set; }

        public bool IsActive { get; set; }=true;

    }
}
