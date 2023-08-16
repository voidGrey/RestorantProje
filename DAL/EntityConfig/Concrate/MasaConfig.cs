using Entites.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entites.Concrate
{
    public class MasaConfig : BaseConfig<Masa>
    {
        public override void Configure(EntityTypeBuilder<Masa> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => x.MasaID).IsUnique();


            builder.HasData(new Masa { ID = 1, MasaID = 1},
                new Masa { ID = 2, MasaID = 2 },
                new Masa { ID = 3, MasaID = 3 });
        }
    }
}