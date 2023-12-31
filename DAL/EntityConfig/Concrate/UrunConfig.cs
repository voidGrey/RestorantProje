﻿using Entites.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entites.Concrate
{
    public class UrunConfig : BaseConfig<Urun>
    {
        public override void Configure(EntityTypeBuilder<Urun> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.UrunAdi).HasColumnType("nvarchar(max)");
            builder.Property(x => x.UrunAciklama).HasColumnType("nvarchar(max)");
        }
    }
}