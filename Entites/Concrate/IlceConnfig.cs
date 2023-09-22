using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrate
{
    public class IlceConfig : IEntityTypeConfiguration<Ilce>
    {
        public void Configure(EntityTypeBuilder<Ilce> builder)
        {
            builder.Property(p => p.IlceAdi).HasMaxLength(50);

        }
    }
}
