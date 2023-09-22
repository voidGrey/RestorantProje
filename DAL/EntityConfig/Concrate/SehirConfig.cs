using Entites.Abstract;
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
    public class SehirConfig : IEntityTypeConfiguration<Sehir>
    {
        public void Configure(EntityTypeBuilder<Sehir> builder)
        {
           builder.Property(p=>p.SehirAdi).HasMaxLength(50);
            builder.Property(p => p.PlakaKodu).HasMaxLength(3);
            builder.HasIndex(p=>p.SehirAdi).IsUnique();
            builder.HasIndex(p => p.PlakaKodu).IsUnique();

            builder.HasData
                (
                    new Sehir { Id = 1 , PlakaKodu = "01" , SehirAdi = "Adana" } ,
                    new Sehir { Id = 2 , PlakaKodu = "02" , SehirAdi = "Adıyaman" } ,
                    new Sehir { Id = 3 , PlakaKodu = "03" , SehirAdi = "Afyonkarahisar" } ,
                    new Sehir { Id = 4 , PlakaKodu = "04" , SehirAdi = "Ağrı" } ,
                    new Sehir { Id = 5 , PlakaKodu = "05" , SehirAdi = "Amasya" } ,
                    new Sehir { Id = 6 , PlakaKodu = "06" , SehirAdi = "Ankara" } ,
                    new Sehir { Id = 7 , PlakaKodu = "07" , SehirAdi = "Antalya" } ,
                    new Sehir { Id = 8 , PlakaKodu = "08" , SehirAdi = "Artvin" } ,
                    new Sehir { Id = 9 , PlakaKodu = "09" , SehirAdi = "Aydın" } ,
                    new Sehir { Id = 10 , PlakaKodu = "10" , SehirAdi = "Balıkesir" } ,
                    new Sehir { Id = 11 , PlakaKodu = "11" , SehirAdi = "Bilecik" } ,
                    new Sehir { Id = 12 , PlakaKodu = "12" , SehirAdi = "Bingöl" } ,
                    new Sehir { Id = 13 , PlakaKodu = "13" , SehirAdi = "Bitlis" } ,
                    new Sehir { Id = 14 , PlakaKodu = "14" , SehirAdi = "Bolu" } ,
                    new Sehir { Id = 15 , PlakaKodu = "15" , SehirAdi = "Burdur" } ,
                    new Sehir { Id = 16 , PlakaKodu = "16" , SehirAdi = "Bursa" } ,
                    new Sehir { Id = 17 , PlakaKodu = "17" , SehirAdi = "Çanakkale" } ,
                    new Sehir { Id = 18 , PlakaKodu = "18" , SehirAdi = "Çankırı" } ,
                    new Sehir { Id = 19 , PlakaKodu = "19" , SehirAdi = "Çorum" } ,
                    new Sehir { Id = 20 , PlakaKodu = "20" , SehirAdi = "Denizli" } ,
                    new Sehir { Id = 21 , PlakaKodu = "21" , SehirAdi = "Diyarbakır" } ,
                    new Sehir { Id = 22 , PlakaKodu = "22" , SehirAdi = "Edirne" } ,
                    new Sehir { Id = 23 , PlakaKodu = "23" , SehirAdi = "Elazığ" } ,
                    new Sehir { Id = 24 , PlakaKodu = "24" , SehirAdi = "Erzincan" } ,
                    new Sehir { Id = 25 , PlakaKodu = "25" , SehirAdi = "Erzurum" } ,
                    new Sehir { Id = 26 , PlakaKodu = "26" , SehirAdi = "Eskişehir" } ,
                    new Sehir { Id = 27 , PlakaKodu = "27" , SehirAdi = "Gaziantep" } ,
                    new Sehir { Id = 28 , PlakaKodu = "28" , SehirAdi = "Giresun" } ,
                    new Sehir { Id = 29 , PlakaKodu = "29" , SehirAdi = "Gümüşhane" } ,
                    new Sehir { Id = 30 , PlakaKodu = "30" , SehirAdi = "Hakkâri" } ,
                    new Sehir { Id = 31 , PlakaKodu = "31" , SehirAdi = "Hatay" } ,
                    new Sehir { Id = 32 , PlakaKodu = "32" , SehirAdi = "Isparta" } ,
                    new Sehir { Id = 33 , PlakaKodu = "33" , SehirAdi = "Mersin" } ,
                    new Sehir { Id = 34 , PlakaKodu = "34" , SehirAdi = "Istanbul" } ,
                    new Sehir { Id = 35 , PlakaKodu = "35" , SehirAdi = "İzmir" } ,
                    new Sehir { Id = 36 , PlakaKodu = "36" , SehirAdi = "Kars" } ,
                    new Sehir { Id = 37 , PlakaKodu = "37" , SehirAdi = "Kastamonu" } ,
                    new Sehir { Id = 38 , PlakaKodu = "38" , SehirAdi = "Kayseri" } ,
                    new Sehir { Id = 39 , PlakaKodu = "39" , SehirAdi = "Kırklareli" } ,
                    new Sehir { Id = 40 , PlakaKodu = "40" , SehirAdi = "Kırşehir" } ,
                    new Sehir { Id = 41 , PlakaKodu = "41" , SehirAdi = "Kocaeli" } ,
                    new Sehir { Id = 42 , PlakaKodu = "42" , SehirAdi = "Konya" } ,
                    new Sehir { Id = 43 , PlakaKodu = "43" , SehirAdi = "Kütahya" } ,
                    new Sehir { Id = 44 , PlakaKodu = "44" , SehirAdi = "Malatya" } ,
                    new Sehir { Id = 45 , PlakaKodu = "45" , SehirAdi = "Manisa" } ,
                    new Sehir { Id = 46 , PlakaKodu = "46" , SehirAdi = "Kahramanmaraş" } ,
                    new Sehir { Id = 47 , PlakaKodu = "47" , SehirAdi = "Mardin" } ,
                    new Sehir { Id = 48 , PlakaKodu = "48" , SehirAdi = "Muğla" } ,
                    new Sehir { Id = 49 , PlakaKodu = "49" , SehirAdi = "Muş" } ,
                    new Sehir { Id = 50 , PlakaKodu = "50" , SehirAdi = "Nevşehir" } ,
                    new Sehir { Id = 51 , PlakaKodu = "51" , SehirAdi = "Niğde" } ,
                    new Sehir { Id = 52 , PlakaKodu = "52" , SehirAdi = "Ordu" } ,
                    new Sehir { Id = 53 , PlakaKodu = "53" , SehirAdi = "Rize" } ,
                    new Sehir { Id = 54 , PlakaKodu = "54" , SehirAdi = "Sakarya" } ,
                    new Sehir { Id = 55 , PlakaKodu = "55" , SehirAdi = "Samsun" } ,
                    new Sehir { Id = 56 , PlakaKodu = "56" , SehirAdi = "Siirt" } ,
                    new Sehir { Id = 57 , PlakaKodu = "57" , SehirAdi = "Sinop" } ,
                    new Sehir { Id = 58 , PlakaKodu = "58" , SehirAdi = "Sivas" } ,
                    new Sehir { Id = 59 , PlakaKodu = "59" , SehirAdi = "Tekirdağ" } ,
                    new Sehir { Id = 60 , PlakaKodu = "60" , SehirAdi = "Tokat" } ,
                    new Sehir { Id = 61 , PlakaKodu = "61" , SehirAdi = "Trabzon" } ,
                    new Sehir { Id = 62 , PlakaKodu = "62" , SehirAdi = "Tunceli" } ,
                    new Sehir { Id = 63 , PlakaKodu = "63" , SehirAdi = "Şanlıurfa" } ,
                    new Sehir { Id = 64 , PlakaKodu = "64" , SehirAdi = "Uşak" } ,
                    new Sehir { Id = 65 , PlakaKodu = "65" , SehirAdi = "Van" } ,
                    new Sehir { Id = 66 , PlakaKodu = "66" , SehirAdi = "Yozgat" } ,
                    new Sehir { Id = 67 , PlakaKodu = "67" , SehirAdi = "Zonguldak" } ,
                    new Sehir { Id = 68 , PlakaKodu = "68" , SehirAdi = "Aksaray" } ,
                    new Sehir { Id = 69 , PlakaKodu = "69" , SehirAdi = "Bayburt" } ,
                    new Sehir { Id = 70 , PlakaKodu = "70" , SehirAdi = "Karaman" } ,
                    new Sehir { Id = 71 , PlakaKodu = "71" , SehirAdi = "Kırıkkale" } ,
                    new Sehir { Id = 72 , PlakaKodu = "72" , SehirAdi = "Batman" } ,
                    new Sehir { Id = 73 , PlakaKodu = "73" , SehirAdi = "Şırnak" } ,
                    new Sehir { Id = 74 , PlakaKodu = "74" , SehirAdi = "Bartın" } ,
                    new Sehir { Id = 75 , PlakaKodu = "75" , SehirAdi = "Ardahan" } ,
                    new Sehir { Id = 76 , PlakaKodu = "76" , SehirAdi = "Iğdır" } ,
                    new Sehir { Id = 77 , PlakaKodu = "77" , SehirAdi = "Yalova" } ,
                    new Sehir { Id = 78 , PlakaKodu = "78" , SehirAdi = "Karabük" } ,
                    new Sehir { Id = 79 , PlakaKodu = "79" , SehirAdi = "Kilis" } ,
                    new Sehir { Id = 80 , PlakaKodu = "80" , SehirAdi = "Osmaniye" } ,
                    new Sehir { Id = 81 , PlakaKodu = "81" , SehirAdi = "Düzce" }
                );

        }
    }
}
