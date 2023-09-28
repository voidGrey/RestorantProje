using Entites.Abstract;
using Entites.Concrate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityConfig.Concrate
{
    public class SiparisDetayConfig:BaseConfig<SiparisDetay>
    {
        public override void Configure(EntityTypeBuilder<SiparisDetay> builder)
        {
            base.Configure(builder);
            builder.HasIndex(p => new { p.SiparisMasterId, p.UrunId }).IsUnique();
        }
    }
}
