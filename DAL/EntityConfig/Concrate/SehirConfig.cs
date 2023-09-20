using Entites.Abstract;
using Entites.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityConfig.Concrate
{
    public class SehirConfig : IEntityTypeConfiguration<Sehir>
    {
        public void Configure(EntityTypeBuilder<Sehir> builder)
        {
           builder.Property(p=>p.SehirAdi).HasMaxLength(50);
            builder.Property(p => p.PlakaKodu).HasMaxLength(3);
            builder.HasIndex(p=>p.SehirAdi).IsUnique();
            builder.HasIndex(p => p.PlakaKodu).IsUnique();

        }
    }
}
