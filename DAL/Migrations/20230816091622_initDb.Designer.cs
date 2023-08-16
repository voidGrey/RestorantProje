﻿// <auto-generated />
using System;
using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20230816091622_initDb")]
    partial class initDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasDefaultValue(new DateTime(2023, 8, 16, 12, 16, 22, 308, DateTimeKind.Local).AddTicks(9250));

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
                            CreateTime = new DateTime(2023, 8, 16, 12, 16, 22, 308, DateTimeKind.Local).AddTicks(9866),
                            KategoriAciklama = "Yiyecekler",
                            KategoriAdi = "Ana Yemek",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 2,
                            CreateTime = new DateTime(2023, 8, 16, 12, 16, 22, 308, DateTimeKind.Local).AddTicks(9869),
                            KategoriAciklama = "Çorba v.b.",
                            KategoriAdi = "Ara Sıcaklar",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 3,
                            CreateTime = new DateTime(2023, 8, 16, 12, 16, 22, 308, DateTimeKind.Local).AddTicks(9870),
                            KategoriAciklama = "Tatlılar",
                            KategoriAdi = "Tatlı",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 4,
                            CreateTime = new DateTime(2023, 8, 16, 12, 16, 22, 308, DateTimeKind.Local).AddTicks(9871),
                            KategoriAciklama = "Şarap v.b.",
                            KategoriAdi = "Alkollü İçecekelr",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 5,
                            CreateTime = new DateTime(2023, 8, 16, 12, 16, 22, 308, DateTimeKind.Local).AddTicks(9872),
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
                        .HasDefaultValue(new DateTime(2023, 8, 16, 12, 16, 22, 309, DateTimeKind.Local).AddTicks(1404));

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
                            CreateTime = new DateTime(2023, 8, 16, 12, 16, 22, 309, DateTimeKind.Local).AddTicks(1875),
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
                        .HasDefaultValue(new DateTime(2023, 8, 16, 12, 16, 22, 309, DateTimeKind.Local).AddTicks(4155));

                    b.Property<int>("MasaID")
                        .HasColumnType("int");

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

            modelBuilder.Entity("Entites.Concrate.Siparis", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 8, 16, 12, 16, 22, 309, DateTimeKind.Local).AddTicks(2997));

                    b.Property<int>("MasaID")
                        .HasColumnType("int");

                    b.Property<double>("ToplamFiyat")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("MasaID");

                    b.ToTable("Siparisler");
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
                        .HasDefaultValue(new DateTime(2023, 8, 16, 12, 16, 22, 309, DateTimeKind.Local).AddTicks(5463));

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("FotografLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriID")
                        .HasColumnType("int");

                    b.Property<int?>("SiparisID")
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

                    b.HasIndex("SiparisID");

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

            modelBuilder.Entity("Entites.Concrate.Siparis", b =>
                {
                    b.HasOne("Entites.Concrate.Masa", "Masa")
                        .WithMany("Siparisler")
                        .HasForeignKey("MasaID")
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

                    b.HasOne("Entites.Concrate.Siparis", null)
                        .WithMany("Urunler")
                        .HasForeignKey("SiparisID");

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("Entites.Concrate.Kategori", b =>
                {
                    b.Navigation("Stoklar");
                });

            modelBuilder.Entity("Entites.Concrate.Masa", b =>
                {
                    b.Navigation("Siparisler");
                });

            modelBuilder.Entity("Entites.Concrate.Siparis", b =>
                {
                    b.Navigation("Urunler");
                });
#pragma warning restore 612, 618
        }
    }
}
