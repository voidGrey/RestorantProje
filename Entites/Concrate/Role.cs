using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrate
{
    public class Role :BaseEntity
    {

        public string RoleAdi { get; set; }
        public ICollection<Kullanici>? Kullanicilar { get; set; }
    }
}
