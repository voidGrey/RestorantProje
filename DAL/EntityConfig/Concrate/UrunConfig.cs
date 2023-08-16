using Entites.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entites.Concrate
{
    public class UrunConfig : BaseConfig<Urun>
    {
        public override void Configure(EntityTypeBuilder<Urun> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.UrunAdi).HasMaxLength(20);
            builder.Property(x => x.UrunAciklama).HasMaxLength(50);
            builder.HasIndex(x => x.UrunAdi).IsUnique();

            builder.HasData(
                new Urun { ID = 1 , UrunAdi = "Tuborg Gold" , UrunAciklama = "50" , KategoriID = 4 , Fiyat = 80.0 } ,
                new Urun { ID = 2 , UrunAdi = "Tuborg Red" , UrunAciklama = "50" , KategoriID = 4 , Fiyat = 85.0 } ,
                new Urun { ID = 3 , UrunAdi = "Viski Single" , UrunAciklama = "50" , KategoriID = 4 , Fiyat = 120.0 } ,
                new Urun { ID = 4 , UrunAdi = "Viski Double" , UrunAciklama = "50" , KategoriID = 4 , Fiyat = 240.0 } ,
                new Urun { ID = 5 , UrunAdi = "Vodka" , UrunAciklama = "50" , KategoriID = 4 , Fiyat = 100.0 } ,
                new Urun { ID = 6 , UrunAdi = "Cin" , UrunAciklama = "50" , KategoriID = 4 , Fiyat = 100.0 } ,

                new Urun { ID = 7 , UrunAdi = "Biftek" , UrunAciklama = "Izgara biftek" , KategoriID = 1 , Fiyat = 240.0 } ,
                new Urun { ID = 8 , UrunAdi = "Makarna" , UrunAciklama = "Makarna" , KategoriID = 1 , Fiyat = 200.0 } ,
                new Urun { ID = 9 , UrunAdi = "Pilav" , UrunAciklama = "Pilav" , KategoriID = 1 , Fiyat = 100.0 } ,
                new Urun { ID = 10 , UrunAdi = "Tavuk" , UrunAciklama = "Izgara tavuk" , KategoriID = 1 , Fiyat = 100.0 } ,
                new Urun { ID = 11 , UrunAdi = "Köfte" , UrunAciklama = "Izgara köfte" , KategoriID = 1 , Fiyat = 180.0 } ,
                new Urun { ID = 12 , UrunAdi = "İskender" , UrunAciklama = "bursa iskender" , KategoriID = 1 , Fiyat = 200.0 } ,

                new Urun { ID = 13 , UrunAdi = "Güllaç" , UrunAciklama = "güllaç" , KategoriID = 3 , Fiyat = 240.0 } ,
                new Urun { ID = 14 , UrunAdi = "Kazandibi" , UrunAciklama = "kazandibi" , KategoriID = 3 , Fiyat = 240.0 } ,
                new Urun { ID = 15 , UrunAdi = "Tavuk göğüsü" , UrunAciklama = "kazandibi" , KategoriID = 3 , Fiyat = 240.0 } ,
                new Urun { ID = 16 , UrunAdi = "Sufle" , UrunAciklama = "kazandibi" , KategoriID = 3 , Fiyat = 240.0 } ,
                new Urun { ID = 17 , UrunAdi = "Cheese Kek" , UrunAciklama = "kazandibi" , KategoriID = 3 , Fiyat = 240.0 } ,

                new Urun { ID = 18 , UrunAdi = "Kola" , UrunAciklama = "Kola" , KategoriID = 5 , Fiyat = 24.0 } ,
                new Urun { ID = 19 , UrunAdi = "Sarı Kola" , UrunAciklama = "Sarı Kola" , KategoriID = 5 , Fiyat = 24.0 } ,
                new Urun { ID = 20 , UrunAdi = "Su" , UrunAciklama = "Su" , KategoriID = 5 , Fiyat = 14.0 } ,
                new Urun { ID = 21 , UrunAdi = "Gazoz" , UrunAciklama = "Gazoz" , KategoriID = 5 , Fiyat = 24.0 } ,
                new Urun { ID = 22 , UrunAdi = "Ayran" , UrunAciklama = "Ayran" , KategoriID = 5 , Fiyat = 24.0 } ,
                new Urun { ID = 23 , UrunAdi = "Çay" , UrunAciklama = "Çay" , KategoriID = 5 , Fiyat = 14.0 } ,

                new Urun { ID = 24 , UrunAdi = "Mercimek Ç." , UrunAciklama = "kazandibi" , KategoriID = 2 , Fiyat = 14.0 } ,
                new Urun { ID = 25 , UrunAdi = "Ezogelin Ç." , UrunAciklama = "kazandibi" , KategoriID = 2 , Fiyat = 14.0 } ,
                new Urun { ID = 26 , UrunAdi = "Domates Ç." , UrunAciklama = "kazandibi" , KategoriID = 2 , Fiyat = 14.0 } ,
                new Urun { ID = 27 , UrunAdi = "Tarhana Ç." , UrunAciklama = "kazandibi" , KategoriID = 2 , Fiyat = 14.0 } ,
                new Urun { ID = 28 , UrunAdi = "İşembe Ç." , UrunAciklama = "kazandibi" , KategoriID = 2 , Fiyat = 14.0 }

                );
        }
    }
}