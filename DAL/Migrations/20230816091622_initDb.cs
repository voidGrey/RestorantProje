using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KategoriAciklama = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 16, 12, 16, 22, 308, DateTimeKind.Local).AddTicks(9250)),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 16, 12, 16, 22, 309, DateTimeKind.Local).AddTicks(1404)),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Masalar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasaID = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 16, 12, 16, 22, 309, DateTimeKind.Local).AddTicks(4155)),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masalar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToplamFiyat = table.Column<double>(type: "float", nullable: false),
                    MasaID = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 16, 12, 16, 22, 309, DateTimeKind.Local).AddTicks(2997)),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Siparisler_Masalar_MasaID",
                        column: x => x.MasaID,
                        principalTable: "Masalar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UrunAciklama = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FotografLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    SiparisID = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 16, 12, 16, 22, 309, DateTimeKind.Local).AddTicks(5463)),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Urunler_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Urunler_Siparisler_SiparisID",
                        column: x => x.SiparisID,
                        principalTable: "Siparisler",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "ID", "CreateTime", "KategoriAciklama", "KategoriAdi", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 16, 12, 16, 22, 308, DateTimeKind.Local).AddTicks(9866), "Yiyecekler", "Ana Yemek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 8, 16, 12, 16, 22, 308, DateTimeKind.Local).AddTicks(9869), "Çorba v.b.", "Ara Sıcaklar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 8, 16, 12, 16, 22, 308, DateTimeKind.Local).AddTicks(9870), "Tatlılar", "Tatlı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 8, 16, 12, 16, 22, 308, DateTimeKind.Local).AddTicks(9871), "Şarap v.b.", "Alkollü İçecekelr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 8, 16, 12, 16, 22, 308, DateTimeKind.Local).AddTicks(9872), "Kola, su v.b.", "Alkolsüz İçecekler", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "ID", "CreateTime", "KullaniciAdi", "Sifre", "UpdateTime" },
                values: new object[] { 1, new DateTime(2023, 8, 16, 12, 16, 22, 309, DateTimeKind.Local).AddTicks(1875), "Admin", "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Masalar",
                columns: new[] { "ID", "MasaID", "UpdateTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "ID", "Fiyat", "FotografLink", "KategoriID", "SiparisID", "UpdateTime", "UrunAciklama", "UrunAdi" },
                values: new object[,]
                {
                    { 1, 80.0, null, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", "Tuborg Gold" },
                    { 2, 85.0, null, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", "Tuborg Red" },
                    { 3, 120.0, null, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", "Viski Single" },
                    { 4, 240.0, null, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", "Viski Double" },
                    { 5, 100.0, null, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", "Vodka" },
                    { 6, 100.0, null, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", "Cin" },
                    { 7, 240.0, null, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Izgara biftek", "Biftek" },
                    { 8, 200.0, null, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Makarna", "Makarna" },
                    { 9, 100.0, null, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pilav", "Pilav" },
                    { 10, 100.0, null, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Izgara tavuk", "Tavuk" },
                    { 11, 180.0, null, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Izgara köfte", "Köfte" },
                    { 12, 200.0, null, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bursa iskender", "İskender" },
                    { 13, 240.0, null, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "güllaç", "Güllaç" },
                    { 14, 240.0, null, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kazandibi", "Kazandibi" },
                    { 15, 240.0, null, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kazandibi", "Tavuk göğüsü" },
                    { 16, 240.0, null, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kazandibi", "Sufle" },
                    { 17, 240.0, null, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kazandibi", "Cheese Kek" },
                    { 18, 24.0, null, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kola", "Kola" },
                    { 19, 24.0, null, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarı Kola", "Sarı Kola" },
                    { 20, 14.0, null, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Su", "Su" },
                    { 21, 24.0, null, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gazoz", "Gazoz" },
                    { 22, 24.0, null, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ayran", "Ayran" },
                    { 23, 14.0, null, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çay", "Çay" },
                    { 24, 14.0, null, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kazandibi", "Mercimek Ç." },
                    { 25, 14.0, null, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kazandibi", "Ezogelin Ç." },
                    { 26, 14.0, null, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kazandibi", "Domates Ç." },
                    { 27, 14.0, null, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kazandibi", "Tarhana Ç." },
                    { 28, 14.0, null, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kazandibi", "İşembe Ç." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_KategoriAdi",
                table: "Kategoriler",
                column: "KategoriAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_KullaniciAdi",
                table: "Kullanicilar",
                column: "KullaniciAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Masalar_MasaID",
                table: "Masalar",
                column: "MasaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_MasaID",
                table: "Siparisler",
                column: "MasaID");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_KategoriID",
                table: "Urunler",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_SiparisID",
                table: "Urunler",
                column: "SiparisID");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_UrunAdi",
                table: "Urunler",
                column: "UrunAdi",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Masalar");
        }
    }
}
