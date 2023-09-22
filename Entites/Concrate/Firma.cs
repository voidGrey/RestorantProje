using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Entites.Concrate
{
    public class Firma : IdentityUser
    {
     
        public string FirmaAdi { get; set; }
        public Adres? Adres { get; set; }

        public string? VergiDairesi { get; set; }
        public string? VergiNo  { get; set; }

       
    }
}
