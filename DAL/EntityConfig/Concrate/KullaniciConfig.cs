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
    public class KullaniciConfig : BaseConfig<Kullanici>
    {
        public override void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            base.Configure(builder);

            builder.Property(b => b.Sifre).HasMaxLength(50);
            builder.Property(b => b.KullaniciAdi).HasMaxLength(50);
            builder.HasIndex(b => b.KullaniciAdi).IsUnique();

            builder.HasData(
                new Kullanici { ID = 1, KullaniciAdi = "Admin", Sifre = "123", CreateTime = DateTime.Now}
                );
        }
    }
}
