using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrate
{
    public class Kasa:BaseEntity
    {
        public string KasaAdi { get; set; }
        public double Tutar { get; set; }
        public ICollection<KasaHareket> KasaHareketleri { get; set; }
    }
}
