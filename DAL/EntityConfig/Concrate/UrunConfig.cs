using Entites.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entites.Concrate
{
    public class UrunConfig : BaseConfig<Urun>
    {
        public override void Configure(EntityTypeBuilder<Urun> builder)
        {
            base.Configure(builder);
            builder.Property(x=> x.UrunAdi).HasMaxLength(20);
            builder.Property(x => x.UrunAciklama).HasMaxLength(50);
            builder.HasIndex(x => x.UrunAdi).IsUnique();

            builder.HasData(new Urun { ID = 1, UrunAdi = "Tuborg Gold", UrunAciklama = "50", KategoriID = 4 });
        }
    }
}