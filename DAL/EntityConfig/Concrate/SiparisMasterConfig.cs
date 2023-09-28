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
    public class SiparisMasterConfig:BaseConfig<SiparisMaster>
    {
        public override void Configure(EntityTypeBuilder<SiparisMaster> builder)
        {
            base.Configure(builder);
        }
    }
}
 