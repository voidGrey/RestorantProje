using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrate
{
    public class Sepet : BaseEntity
    {
        public int ToplamFiyat { get; set; }
        public List<Urun> Urunler { get; set; }

        public Masa masa { get; set; }
        public int MasaID { get; set; }
    }
}
