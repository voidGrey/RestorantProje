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
            builder.HasIndex(p => p.KategoriAdi).IsUnique();

            builder.HasData(
                new Kategori { ID = 1 , KategoriAdi = "Ana Yemek" , KategoriAciklama = "Yiyecekler" , CreateTime = DateTime.Now } ,
                new Kategori { ID = 2 , KategoriAdi = "Ara Sıcaklar" , KategoriAciklama = "Çorba v.b." , CreateTime = DateTime.Now } ,
                new Kategori { ID = 3 , KategoriAdi = "Tatlı" , KategoriAciklama = "Tatlılar" , CreateTime = DateTime.Now } ,
                new Kategori { ID = 4 , KategoriAdi = "Alkollü İçecekelr" , KategoriAciklama = "Şarap v.b." , CreateTime = DateTime.Now } ,
                new Kategori { ID = 5 , KategoriAdi = "Alkolsüz İçecekler" , KategoriAciklama = "Kola, su v.b." , CreateTime = DateTime.Now }
                );
        }
    }
}