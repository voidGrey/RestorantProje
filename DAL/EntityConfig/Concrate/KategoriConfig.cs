using Entites.Abstract;
using Entites.Concrate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfig.Concrate
{
    public class KategoriConfig : BaseConfig<Kategori>
    {
        public override void Configure(EntityTypeBuilder<Kategori> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.KategoriAdi).HasMaxLength(50);
            builder.Property(p => p.KategoriAciklama).HasMaxLength(100);
        }
    }
}