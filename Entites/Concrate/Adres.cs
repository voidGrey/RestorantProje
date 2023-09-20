using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrate
{
    public  class Adres : BaseEntity
    {

        public int SehirId { get; set; }
        public Sehir Sehir { get; set; }
        public int IlceId { get; set; }
        public Ilce  Ilce { get; set; }

        public string CaddeSokak { get; set; }

        public string PostaKodu { get; set; }

    }
}
