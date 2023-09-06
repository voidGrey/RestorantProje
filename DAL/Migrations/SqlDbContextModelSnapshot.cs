﻿// <auto-generated />
using System;
using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entites.Concrate.Kategori", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
<<<<<<< HEAD
                        .HasDefaultValue(new DateTime(2023, 9, 6, 12, 53, 36, 595, DateTimeKind.Local).AddTicks(6951));
=======
                        .HasDefaultValue(new DateTime(2023, 9, 6, 12, 36, 30, 721, DateTimeKind.Local).AddTicks(251));
>>>>>>> 110eada12b11c098a1d34df1a988920ecd0076a6

                    b.Property<string>("KategoriAciklama")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("KategoriAdi")
                        .IsUnique();

                    b.ToTable("Kategoriler");

                    b.HasData(
                        new
                        {
                            ID = 1,
<<<<<<< HEAD
                            CreateTime = new DateTime(2023, 9, 6, 12, 53, 36, 595, DateTimeKind.Local).AddTicks(7596),
=======
                            CreateTime = new DateTime(2023, 9, 6, 12, 36, 30, 721, DateTimeKind.Local).AddTicks(1624),
>>>>>>> 110eada12b11c098a1d34df1a988920ecd0076a6
                            KategoriAciklama = "Yiyecekler",
                            KategoriAdi = "Ana Yemek",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 2,
<<<<<<< HEAD
                            CreateTime = new DateTime(2023, 9, 6, 12, 53, 36, 595, DateTimeKind.Local).AddTicks(7598),
=======
                            CreateTime = new DateTime(2023, 9, 6, 12, 36, 30, 721, DateTimeKind.Local).AddTicks(1630),
>>>>>>> 110eada12b11c098a1d34df1a988920ecd0076a6
                            KategoriAciklama = "Çorba v.b.",
                            KategoriAdi = "Ara Sıcaklar",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 3,
<<<<<<< HEAD
                            CreateTime = new DateTime(2023, 9, 6, 12, 53, 36, 595, DateTimeKind.Local).AddTicks(7600),
=======
                            CreateTime = new DateTime(2023, 9, 6, 12, 36, 30, 721, DateTimeKind.Local).AddTicks(1703),
>>>>>>> 110eada12b11c098a1d34df1a988920ecd0076a6
                            KategoriAciklama = "Tatlılar",
                            KategoriAdi = "Tatlı",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 4,
<<<<<<< HEAD
                            CreateTime = new DateTime(2023, 9, 6, 12, 53, 36, 595, DateTimeKind.Local).AddTicks(7600),
=======
                            CreateTime = new DateTime(2023, 9, 6, 12, 36, 30, 721, DateTimeKind.Local).AddTicks(1706),
>>>>>>> 110eada12b11c098a1d34df1a988920ecd0076a6
                            KategoriAciklama = "Şarap v.b.",
                            KategoriAdi = "Alkollü İçecekelr",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 5,
<<<<<<< HEAD
                            CreateTime = new DateTime(2023, 9, 6, 12, 53, 36, 595, DateTimeKind.Local).AddTicks(7601),
=======
                            CreateTime = new DateTime(2023, 9, 6, 12, 36, 30, 721, DateTimeKind.Local).AddTicks(1708),
>>>>>>> 110eada12b11c098a1d34df1a988920ecd0076a6
                            KategoriAciklama = "Kola, su v.b.",
                            KategoriAdi = "Alkolsüz İçecekler",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Entites.Concrate.Kullanici", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
<<<<<<< HEAD
                        .HasDefaultValue(new DateTime(2023, 9, 6, 12, 53, 36, 595, DateTimeKind.Local).AddTicks(9055));
=======
                        .HasDefaultValue(new DateTime(2023, 9, 6, 12, 36, 30, 721, DateTimeKind.Local).AddTicks(4709));
>>>>>>> 110eada12b11c098a1d34df1a988920ecd0076a6

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("KullaniciAdi")
                        .IsUnique();

                    b.ToTable("Kullanicilar");

                    b.HasData(
                        new
                        {
                            ID = 1,
<<<<<<< HEAD
                            CreateTime = new DateTime(2023, 9, 6, 12, 53, 36, 595, DateTimeKind.Local).AddTicks(9655),
=======
                            CreateTime = new DateTime(2023, 9, 6, 12, 36, 30, 721, DateTimeKind.Local).AddTicks(5994),
>>>>>>> 110eada12b11c098a1d34df1a988920ecd0076a6
                            KullaniciAdi = "Admin",
                            Sifre = "123",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Entites.Concrate.Masa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
<<<<<<< HEAD
                        .HasDefaultValue(new DateTime(2023, 9, 6, 12, 53, 36, 596, DateTimeKind.Local).AddTicks(5446));
=======
                        .HasDefaultValue(new DateTime(2023, 9, 6, 12, 36, 30, 722, DateTimeKind.Local).AddTicks(6576));
>>>>>>> 110eada12b11c098a1d34df1a988920ecd0076a6

                    b.Property<int>("MasaID")
                        .HasColumnType("int");

                    b.Property<string>("MasaSifresi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("MasaID")
                        .IsUnique();

                    b.ToTable("Masalar");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MasaID = 1,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 2,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MasaID = 2,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 3,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MasaID = 3,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Entites.Concrate.SiparisDetay", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("Adet")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
<<<<<<< HEAD
                        .HasDefaultValue(new DateTime(2023, 9, 6, 12, 53, 36, 596, DateTimeKind.Local).AddTicks(1120));
=======
                        .HasDefaultValue(new DateTime(2023, 9, 6, 12, 36, 30, 721, DateTimeKind.Local).AddTicks(8733));
>>>>>>> 110eada12b11c098a1d34df1a988920ecd0076a6

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<int>("SiparisMasterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UrunId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SiparisMasterId");

                    b.HasIndex("UrunId");

                    b.HasIndex("ID", "UrunId")
                        .IsUnique();

                    b.ToTable("SiparisDetaylar");
                });

            modelBuilder.Entity("Entites.Concrate.SiparisMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
<<<<<<< HEAD
                        .HasDefaultValue(new DateTime(2023, 9, 6, 12, 53, 36, 596, DateTimeKind.Local).AddTicks(3877));
=======
                        .HasDefaultValue(new DateTime(2023, 9, 6, 12, 36, 30, 722, DateTimeKind.Local).AddTicks(3687));
>>>>>>> 110eada12b11c098a1d34df1a988920ecd0076a6

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MasaId")
                        .HasColumnType("int");

                    b.Property<double?>("ToplamTutar")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("MasaId")
                        .IsUnique();

                    b.ToTable("SiparisMasterlar");
                });

            modelBuilder.Entity("Entites.Concrate.Urun", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
<<<<<<< HEAD
                        .HasDefaultValue(new DateTime(2023, 9, 6, 12, 53, 36, 596, DateTimeKind.Local).AddTicks(7223));
=======
                        .HasDefaultValue(new DateTime(2023, 9, 6, 12, 36, 30, 723, DateTimeKind.Local).AddTicks(624));
>>>>>>> 110eada12b11c098a1d34df1a988920ecd0076a6

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("FotografLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UrunAciklama")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UrunAdi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.HasIndex("KategoriID");

                    b.HasIndex("UrunAdi")
                        .IsUnique();

                    b.ToTable("Urunler");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 80.0,
                            KategoriID = 4,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "50",
                            UrunAdi = "Tuborg Gold"
                        },
                        new
                        {
                            ID = 2,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 85.0,
                            KategoriID = 4,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "50",
                            UrunAdi = "Tuborg Red"
                        },
                        new
                        {
                            ID = 3,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 120.0,
                            KategoriID = 4,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "50",
                            UrunAdi = "Viski Single"
                        },
                        new
                        {
                            ID = 4,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 240.0,
                            KategoriID = 4,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "50",
                            UrunAdi = "Viski Double"
                        },
                        new
                        {
                            ID = 5,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 100.0,
                            KategoriID = 4,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "50",
                            UrunAdi = "Vodka"
                        },
                        new
                        {
                            ID = 6,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 100.0,
                            KategoriID = 4,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "50",
                            UrunAdi = "Cin"
                        },
                        new
                        {
                            ID = 7,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 240.0,
                            KategoriID = 1,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "Izgara biftek",
                            UrunAdi = "Biftek"
                        },
                        new
                        {
                            ID = 8,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 200.0,
                            KategoriID = 1,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "Makarna",
                            UrunAdi = "Makarna"
                        },
                        new
                        {
                            ID = 9,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 100.0,
                            KategoriID = 1,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "Pilav",
                            UrunAdi = "Pilav"
                        },
                        new
                        {
                            ID = 10,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 100.0,
                            KategoriID = 1,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "Izgara tavuk",
                            UrunAdi = "Tavuk"
                        },
                        new
                        {
                            ID = 11,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 180.0,
                            KategoriID = 1,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "Izgara köfte",
                            UrunAdi = "Köfte"
                        },
                        new
                        {
                            ID = 12,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 200.0,
                            KategoriID = 1,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "bursa iskender",
                            UrunAdi = "İskender"
                        },
                        new
                        {
                            ID = 13,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 240.0,
                            KategoriID = 3,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "güllaç",
                            UrunAdi = "Güllaç"
                        },
                        new
                        {
                            ID = 14,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 240.0,
                            KategoriID = 3,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "kazandibi",
                            UrunAdi = "Kazandibi"
                        },
                        new
                        {
                            ID = 15,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 240.0,
                            KategoriID = 3,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "kazandibi",
                            UrunAdi = "Tavuk göğüsü"
                        },
                        new
                        {
                            ID = 16,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 240.0,
                            KategoriID = 3,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "kazandibi",
                            UrunAdi = "Sufle"
                        },
                        new
                        {
                            ID = 17,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 240.0,
                            KategoriID = 3,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "kazandibi",
                            UrunAdi = "Cheese Kek"
                        },
                        new
                        {
                            ID = 18,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 24.0,
                            KategoriID = 5,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "Kola",
                            UrunAdi = "Kola"
                        },
                        new
                        {
                            ID = 19,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 24.0,
                            KategoriID = 5,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "Sarı Kola",
                            UrunAdi = "Sarı Kola"
                        },
                        new
                        {
                            ID = 20,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 14.0,
                            KategoriID = 5,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "Su",
                            UrunAdi = "Su"
                        },
                        new
                        {
                            ID = 21,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 24.0,
                            KategoriID = 5,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "Gazoz",
                            UrunAdi = "Gazoz"
                        },
                        new
                        {
                            ID = 22,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 24.0,
                            KategoriID = 5,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "Ayran",
                            UrunAdi = "Ayran"
                        },
                        new
                        {
                            ID = 23,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 14.0,
                            KategoriID = 5,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "Çay",
                            UrunAdi = "Çay"
                        },
                        new
                        {
                            ID = 24,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 14.0,
                            KategoriID = 2,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "kazandibi",
                            UrunAdi = "Mercimek Ç."
                        },
                        new
                        {
                            ID = 25,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 14.0,
                            KategoriID = 2,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "kazandibi",
                            UrunAdi = "Ezogelin Ç."
                        },
                        new
                        {
                            ID = 26,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 14.0,
                            KategoriID = 2,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "kazandibi",
                            UrunAdi = "Domates Ç."
                        },
                        new
                        {
                            ID = 27,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 14.0,
                            KategoriID = 2,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "kazandibi",
                            UrunAdi = "Tarhana Ç."
                        },
                        new
                        {
                            ID = 28,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fiyat = 14.0,
                            KategoriID = 2,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UrunAciklama = "kazandibi",
                            UrunAdi = "İşembe Ç."
                        });
                });

            modelBuilder.Entity("Entites.Concrate.SiparisDetay", b =>
                {
                    b.HasOne("Entites.Concrate.SiparisMaster", "SiparisMaster")
                        .WithMany("SiparisDetay")
                        .HasForeignKey("SiparisMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entites.Concrate.Urun", "Urun")
                        .WithMany()
                        .HasForeignKey("UrunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SiparisMaster");

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("Entites.Concrate.SiparisMaster", b =>
                {
                    b.HasOne("Entites.Concrate.Masa", "Masa")
                        .WithOne("Siparis")
                        .HasForeignKey("Entites.Concrate.SiparisMaster", "MasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Masa");
                });

            modelBuilder.Entity("Entites.Concrate.Urun", b =>
                {
                    b.HasOne("Entites.Concrate.Kategori", "Kategori")
                        .WithMany("Stoklar")
                        .HasForeignKey("KategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("Entites.Concrate.Kategori", b =>
                {
                    b.Navigation("Stoklar");
                });

            modelBuilder.Entity("Entites.Concrate.Masa", b =>
                {
                    b.Navigation("Siparis");
                });

            modelBuilder.Entity("Entites.Concrate.SiparisMaster", b =>
                {
                    b.Navigation("SiparisDetay");
                });
#pragma warning restore 612, 618
        }
    }
}
