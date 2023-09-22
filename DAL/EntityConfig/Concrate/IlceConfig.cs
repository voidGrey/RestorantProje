using Entites.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityConfig.Concrate
{
    public class IlceConfig : IEntityTypeConfiguration<Ilce>
    {
        public void Configure(EntityTypeBuilder<Ilce> builder)
        {
            builder.Property(p => p.IlceAdi).HasMaxLength(50);
            builder.Property(p => p.SehirId).HasMaxLength(3);
            builder.HasData
                (
                    new Ilce { Id = 1 , IlceAdi = "Adalar" , SehirId = 34 } ,
                    new Ilce { Id = 2 , IlceAdi = "Arnavutköy" , SehirId = 34 } ,
                    new Ilce { Id = 3 , IlceAdi = "Ataşehir" , SehirId = 34 } ,
                    new Ilce { Id = 4 , IlceAdi = "Avcılar" , SehirId = 34 } ,
                    new Ilce { Id = 5 , IlceAdi = "Bağcılar" , SehirId = 34 } ,
                    new Ilce { Id = 6 , IlceAdi = "Bahçelievler" , SehirId = 34 } ,
                    new Ilce { Id = 7 , IlceAdi = "Bakırköy" , SehirId = 34 } ,
                    new Ilce { Id = 8 , IlceAdi = "Başakşehir" , SehirId = 34 } ,
                    new Ilce { Id = 9 , IlceAdi = "Bayrampaşa" , SehirId = 34 } ,
                    new Ilce { Id = 10 , IlceAdi = "Beşiktaş" , SehirId = 34 } ,
                    new Ilce { Id = 11 , IlceAdi = "Beykoz" , SehirId = 34 } ,
                    new Ilce { Id = 12 , IlceAdi = "Beylikdüzü" , SehirId = 34 } ,
                    new Ilce { Id = 13 , IlceAdi = "Beyoğlu" , SehirId = 34 } ,
                    new Ilce { Id = 14 , IlceAdi = "Büyükçekmece" , SehirId = 34 } ,
                    new Ilce { Id = 15 , IlceAdi = "Çatalca" , SehirId = 34 } ,
                    new Ilce { Id = 16 , IlceAdi = "Çekmeköy" , SehirId = 34 } ,
                    new Ilce { Id = 17 , IlceAdi = "Esenler" , SehirId = 34 } ,
                    new Ilce { Id = 18 , IlceAdi = "Esenyurt" , SehirId = 34 } ,
                    new Ilce { Id = 19 , IlceAdi = "Eyüpsultan" , SehirId = 34 } ,
                    new Ilce { Id = 20 , IlceAdi = "Fatih" , SehirId = 34 } ,
                    new Ilce { Id = 21 , IlceAdi = "Gaziosmanpaşa" , SehirId = 34 } ,
                    new Ilce { Id = 22 , IlceAdi = "Güngören" , SehirId = 34 } ,
                    new Ilce { Id = 23 , IlceAdi = "Kadıköy" , SehirId = 34 } ,
                    new Ilce { Id = 24 , IlceAdi = "Kağıthane" , SehirId = 34 } ,
                    new Ilce { Id = 25 , IlceAdi = "Kartal" , SehirId = 34 } ,
                    new Ilce { Id = 26 , IlceAdi = "Küçükçekmece" , SehirId = 34 } ,
                    new Ilce { Id = 27 , IlceAdi = "Maltepe" , SehirId = 34 } ,
                    new Ilce { Id = 28 , IlceAdi = "Pendik" , SehirId = 34 } ,
                    new Ilce { Id = 29 , IlceAdi = "Sancaktepe" , SehirId = 34 } ,
                    new Ilce { Id = 30 , IlceAdi = "Sarıyer" , SehirId = 34 } ,
                    new Ilce { Id = 31 , IlceAdi = "Silivri" , SehirId = 34 } ,
                    new Ilce { Id = 32 , IlceAdi = "Sultanbeyli" , SehirId = 34 } ,
                    new Ilce { Id = 33 , IlceAdi = "Sultangazi" , SehirId = 34 } ,
                    new Ilce { Id = 34 , IlceAdi = "Şile" , SehirId = 34 } ,
                    new Ilce { Id = 35 , IlceAdi = "Şişli" , SehirId = 34 } ,
                    new Ilce { Id = 36 , IlceAdi = "Tuzla" , SehirId = 34 } ,
                    new Ilce { Id = 37 , IlceAdi = "Ümraniye" , SehirId = 34 } ,
                    new Ilce { Id = 38 , IlceAdi = "Üsküdar" , SehirId = 34 } ,
                    new Ilce { Id = 39 , IlceAdi = "Zeytinburnu" , SehirId = 34 } 
                );
        }
    }
}
