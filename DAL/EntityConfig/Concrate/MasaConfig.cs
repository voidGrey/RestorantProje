using Entites.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entites.Concrate
{
    public class MasaConfig : BaseConfig<Masa>
    {
        public override void Configure(EntityTypeBuilder<Masa> builder)
        {
            base.Configure(builder);
        }
    }
}