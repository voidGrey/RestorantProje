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
    public class RoleConfig:BaseConfig<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            builder.Property(p=>p.RoleAdi).HasMaxLength(50);
            builder.HasIndex(p => p.RoleAdi).IsUnique();
            builder.HasData(new Role() { ID = 1 , RoleAdi = "Admin" , CreateTime = DateTime.Now });
        }
    }
}
