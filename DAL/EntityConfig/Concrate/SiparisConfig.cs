using Entites.Abstract;
using Entites.Concrate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfig.Concrate
{
    public class SiparisConfig : BaseConfig<Siparis>
    {
        public override void Configure(EntityTypeBuilder<Siparis> builder)
        {
            base.Configure(builder);
        }
    }
}