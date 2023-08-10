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
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 10, 14, 52, 57, 540, DateTimeKind.Local).AddTicks(857)),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Masalar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasaID = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 10, 14, 52, 57, 540, DateTimeKind.Local).AddTicks(4166)),
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
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 10, 14, 52, 57, 540, DateTimeKind.Local).AddTicks(2953)),
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
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 10, 14, 52, 57, 540, DateTimeKind.Local).AddTicks(5412)),
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
                    { 1, new DateTime(2023, 8, 10, 14, 52, 57, 540, DateTimeKind.Local).AddTicks(1397), "Yiyecekler", "Ana Yemek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 8, 10, 14, 52, 57, 540, DateTimeKind.Local).AddTicks(1400), "Çorba v.b.", "Ara Sıcaklar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 8, 10, 14, 52, 57, 540, DateTimeKind.Local).AddTicks(1401), "Tatlılar", "Tatlı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 8, 10, 14, 52, 57, 540, DateTimeKind.Local).AddTicks(1402), "Şarap v.b.", "Alkollü İçecekelr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 8, 10, 14, 52, 57, 540, DateTimeKind.Local).AddTicks(1403), "Kola, su v.b.", "Alkolsüz İçecekler", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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
                values: new object[] { 1, 0.0, null, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", "Tuborg Gold" });

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_KategoriAdi",
                table: "Kategoriler",
                column: "KategoriAdi",
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
