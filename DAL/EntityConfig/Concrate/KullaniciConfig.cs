using Entites.Abstract;
using Entites.Concrate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}