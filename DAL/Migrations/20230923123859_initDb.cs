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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirmaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VergiDairesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VergiNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sehirler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlakaKodu = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KategoriAciklama = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirmaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 9, 23, 15, 38, 59, 699, DateTimeKind.Local).AddTicks(6297)),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kategoriler_AspNetUsers_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirmaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 9, 23, 15, 38, 59, 699, DateTimeKind.Local).AddTicks(8085)),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_AspNetUsers_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Masalar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasaID = table.Column<int>(type: "int", nullable: true),
                    MasaSifresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masalar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Masalar_AspNetUsers_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirmaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 9, 23, 15, 38, 59, 699, DateTimeKind.Local).AddTicks(9456)),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Roller_AspNetUsers_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ilceler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirId = table.Column<int>(type: "int", maxLength: 3, nullable: true),
                    IlceAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilceler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ilceler_Sehirler_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehirler",
                        principalColumn: "Id");
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
                    FirmaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 9, 23, 15, 38, 59, 700, DateTimeKind.Local).AddTicks(6481)),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Urunler_AspNetUsers_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Urunler_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiparisMasterlar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasaId = table.Column<int>(type: "int", nullable: true),
                    ToplamTutar = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    FirmaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 9, 23, 15, 38, 59, 700, DateTimeKind.Local).AddTicks(4477)),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisMasterlar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SiparisMasterlar_AspNetUsers_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SiparisMasterlar_Masalar_MasaId",
                        column: x => x.MasaId,
                        principalTable: "Masalar",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRole",
                columns: table => new
                {
                    KullanicilarID = table.Column<int>(type: "int", nullable: false),
                    RollerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRole", x => new { x.KullanicilarID, x.RollerID });
                    table.ForeignKey(
                        name: "FK_KullaniciRole_Kullanicilar_KullanicilarID",
                        column: x => x.KullanicilarID,
                        principalTable: "Kullanicilar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciRole_Roller_RollerID",
                        column: x => x.RollerID,
                        principalTable: "Roller",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirId = table.Column<int>(type: "int", nullable: false),
                    IlceId = table.Column<int>(type: "int", nullable: false),
                    CaddeSokak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostaKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adres_AspNetUsers_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Adres_Ilceler_IlceId",
                        column: x => x.IlceId,
                        principalTable: "Ilceler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adres_Sehirler_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehirler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDetaylar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisMasterId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<double>(type: "float", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    FirmaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 9, 23, 15, 38, 59, 700, DateTimeKind.Local).AddTicks(1976)),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDetaylar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SiparisDetaylar_AspNetUsers_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SiparisDetaylar_SiparisMasterlar_SiparisMasterId",
                        column: x => x.SiparisMasterId,
                        principalTable: "SiparisMasterlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiparisDetaylar_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "ID", "CreateTime", "FirmaId", "KategoriAciklama", "KategoriAdi", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 23, 15, 38, 59, 699, DateTimeKind.Local).AddTicks(6916), null, "Yiyecekler", "Ana Yemek", null },
                    { 2, new DateTime(2023, 9, 23, 15, 38, 59, 699, DateTimeKind.Local).AddTicks(6918), null, "Çorba v.b.", "Ara Sıcaklar", null },
                    { 3, new DateTime(2023, 9, 23, 15, 38, 59, 699, DateTimeKind.Local).AddTicks(6920), null, "Tatlılar", "Tatlı", null },
                    { 4, new DateTime(2023, 9, 23, 15, 38, 59, 699, DateTimeKind.Local).AddTicks(6921), null, "Şarap v.b.", "Alkollü İçecekelr", null },
                    { 5, new DateTime(2023, 9, 23, 15, 38, 59, 699, DateTimeKind.Local).AddTicks(6922), null, "Kola, su v.b.", "Alkolsüz İçecekler", null }
                });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "ID", "CreateTime", "FirmaId", "KullaniciAdi", "Sifre", "UpdateTime" },
                values: new object[] { 1, new DateTime(2023, 9, 23, 15, 38, 59, 699, DateTimeKind.Local).AddTicks(8512), null, "Admin", "123", null });

            migrationBuilder.InsertData(
                table: "Masalar",
                columns: new[] { "ID", "CreateTime", "FirmaId", "MasaID", "MasaSifresi", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "Roller",
                columns: new[] { "ID", "CreateTime", "FirmaId", "RoleAdi", "UpdateTime" },
                values: new object[] { 1, new DateTime(2023, 9, 23, 15, 38, 59, 699, DateTimeKind.Local).AddTicks(9820), null, "Admin", null });

            migrationBuilder.InsertData(
                table: "Sehirler",
                columns: new[] { "Id", "PlakaKodu", "SehirAdi" },
                values: new object[,]
                {
                    { 1, "01", "Adana" },
                    { 2, "02", "Adıyaman" },
                    { 3, "03", "Afyonkarahisar" },
                    { 4, "04", "Ağrı" },
                    { 5, "05", "Amasya" },
                    { 6, "06", "Ankara" },
                    { 7, "07", "Antalya" },
                    { 8, "08", "Artvin" },
                    { 9, "09", "Aydın" },
                    { 10, "10", "Balıkesir" },
                    { 11, "11", "Bilecik" },
                    { 12, "12", "Bingöl" },
                    { 13, "13", "Bitlis" },
                    { 14, "14", "Bolu" },
                    { 15, "15", "Burdur" },
                    { 16, "16", "Bursa" },
                    { 17, "17", "Çanakkale" },
                    { 18, "18", "Çankırı" },
                    { 19, "19", "Çorum" },
                    { 20, "20", "Denizli" },
                    { 21, "21", "Diyarbakır" },
                    { 22, "22", "Edirne" },
                    { 23, "23", "Elazığ" },
                    { 24, "24", "Erzincan" },
                    { 25, "25", "Erzurum" },
                    { 26, "26", "Eskişehir" },
                    { 27, "27", "Gaziantep" },
                    { 28, "28", "Giresun" },
                    { 29, "29", "Gümüşhane" },
                    { 30, "30", "Hakkâri" },
                    { 31, "31", "Hatay" },
                    { 32, "32", "Isparta" },
                    { 33, "33", "Mersin" },
                    { 34, "34", "Istanbul" },
                    { 35, "35", "İzmir" },
                    { 36, "36", "Kars" },
                    { 37, "37", "Kastamonu" },
                    { 38, "38", "Kayseri" },
                    { 39, "39", "Kırklareli" },
                    { 40, "40", "Kırşehir" },
                    { 41, "41", "Kocaeli" },
                    { 42, "42", "Konya" },
                    { 43, "43", "Kütahya" },
                    { 44, "44", "Malatya" },
                    { 45, "45", "Manisa" },
                    { 46, "46", "Kahramanmaraş" },
                    { 47, "47", "Mardin" },
                    { 48, "48", "Muğla" },
                    { 49, "49", "Muş" },
                    { 50, "50", "Nevşehir" },
                    { 51, "51", "Niğde" },
                    { 52, "52", "Ordu" },
                    { 53, "53", "Rize" },
                    { 54, "54", "Sakarya" },
                    { 55, "55", "Samsun" },
                    { 56, "56", "Siirt" },
                    { 57, "57", "Sinop" },
                    { 58, "58", "Sivas" },
                    { 59, "59", "Tekirdağ" },
                    { 60, "60", "Tokat" },
                    { 61, "61", "Trabzon" },
                    { 62, "62", "Tunceli" },
                    { 63, "63", "Şanlıurfa" },
                    { 64, "64", "Uşak" },
                    { 65, "65", "Van" },
                    { 66, "66", "Yozgat" },
                    { 67, "67", "Zonguldak" },
                    { 68, "68", "Aksaray" },
                    { 69, "69", "Bayburt" },
                    { 70, "70", "Karaman" },
                    { 71, "71", "Kırıkkale" },
                    { 72, "72", "Batman" },
                    { 73, "73", "Şırnak" },
                    { 74, "74", "Bartın" },
                    { 75, "75", "Ardahan" },
                    { 76, "76", "Iğdır" },
                    { 77, "77", "Yalova" },
                    { 78, "78", "Karabük" },
                    { 79, "79", "Kilis" },
                    { 80, "80", "Osmaniye" },
                    { 81, "81", "Düzce" }
                });

            migrationBuilder.InsertData(
                table: "Ilceler",
                columns: new[] { "Id", "IlceAdi", "SehirId" },
                values: new object[,]
                {
                    { 1, "Adalar", 34 },
                    { 2, "Arnavutköy", 34 },
                    { 3, "Ataşehir", 34 },
                    { 4, "Avcılar", 34 },
                    { 5, "Bağcılar", 34 },
                    { 6, "Bahçelievler", 34 },
                    { 7, "Bakırköy", 34 },
                    { 8, "Başakşehir", 34 },
                    { 9, "Bayrampaşa", 34 },
                    { 10, "Beşiktaş", 34 },
                    { 11, "Beykoz", 34 },
                    { 12, "Beylikdüzü", 34 },
                    { 13, "Beyoğlu", 34 },
                    { 14, "Büyükçekmece", 34 },
                    { 15, "Çatalca", 34 },
                    { 16, "Çekmeköy", 34 },
                    { 17, "Esenler", 34 },
                    { 18, "Esenyurt", 34 },
                    { 19, "Eyüpsultan", 34 },
                    { 20, "Fatih", 34 },
                    { 21, "Gaziosmanpaşa", 34 },
                    { 22, "Güngören", 34 },
                    { 23, "Kadıköy", 34 },
                    { 24, "Kağıthane", 34 },
                    { 25, "Kartal", 34 },
                    { 26, "Küçükçekmece", 34 },
                    { 27, "Maltepe", 34 },
                    { 28, "Pendik", 34 },
                    { 29, "Sancaktepe", 34 },
                    { 30, "Sarıyer", 34 },
                    { 31, "Silivri", 34 },
                    { 32, "Sultanbeyli", 34 },
                    { 33, "Sultangazi", 34 },
                    { 34, "Şile", 34 },
                    { 35, "Şişli", 34 },
                    { 36, "Tuzla", 34 },
                    { 37, "Ümraniye", 34 },
                    { 38, "Üsküdar", 34 },
                    { 39, "Zeytinburnu", 34 }
                });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "ID", "FirmaId", "Fiyat", "FotografLink", "KategoriID", "UpdateTime", "UrunAciklama", "UrunAdi" },
                values: new object[,]
                {
                    { 1, null, 85.0, null, 4, null, "50", "Tuborg Gold" },
                    { 2, null, 85.0, null, 4, null, "50", "Tuborg Red" },
                    { 3, null, 135.0, null, 4, null, "50", "Viski Single" },
                    { 4, null, 270.0, null, 4, null, "50", "Viski Double" },
                    { 5, null, 120.0, null, 4, null, "50", "Vodka" },
                    { 6, null, 120.0, null, 4, null, "50", "Cin" },
                    { 7, null, 240.0, null, 1, null, "Izgara biftek", "Biftek" },
                    { 8, null, 200.0, null, 1, null, "Makarna", "Makarna" },
                    { 9, null, 100.0, null, 1, null, "Pilav", "Pilav" },
                    { 10, null, 100.0, null, 1, null, "Izgara tavuk", "Tavuk" },
                    { 11, null, 180.0, null, 1, null, "Izgara köfte", "Köfte" },
                    { 12, null, 200.0, null, 1, null, "bursa iskender", "İskender" },
                    { 13, null, 240.0, null, 3, null, "güllaç", "Güllaç" },
                    { 14, null, 240.0, null, 3, null, "kazandibi", "Kazandibi" },
                    { 15, null, 240.0, null, 3, null, "kazandibi", "Tavuk göğüsü" },
                    { 16, null, 240.0, null, 3, null, "kazandibi", "Sufle" },
                    { 17, null, 240.0, null, 3, null, "kazandibi", "Cheese Kek" },
                    { 18, null, 24.0, null, 5, null, "Kola", "Kola" },
                    { 19, null, 24.0, null, 5, null, "Sarı Kola", "Sarı Kola" },
                    { 20, null, 14.0, null, 5, null, "Su", "Su" },
                    { 21, null, 24.0, null, 5, null, "Gazoz", "Gazoz" },
                    { 22, null, 24.0, null, 5, null, "Ayran", "Ayran" },
                    { 23, null, 14.0, null, 5, null, "Çay", "Çay" },
                    { 24, null, 14.0, null, 2, null, "kazandibi", "Mercimek Ç." },
                    { 25, null, 14.0, null, 2, null, "kazandibi", "Ezogelin Ç." },
                    { 26, null, 14.0, null, 2, null, "kazandibi", "Domates Ç." },
                    { 27, null, 14.0, null, 2, null, "kazandibi", "Tarhana Ç." },
                    { 28, null, 14.0, null, 2, null, "kazandibi", "İşembe Ç." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adres_FirmaId",
                table: "Adres",
                column: "FirmaId",
                unique: true,
                filter: "[FirmaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_IlceId",
                table: "Adres",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_SehirId",
                table: "Adres",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ilceler_SehirId",
                table: "Ilceler",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_FirmaId",
                table: "Kategoriler",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_KategoriAdi",
                table: "Kategoriler",
                column: "KategoriAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_FirmaId",
                table: "Kullanicilar",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_KullaniciAdi",
                table: "Kullanicilar",
                column: "KullaniciAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRole_RollerID",
                table: "KullaniciRole",
                column: "RollerID");

            migrationBuilder.CreateIndex(
                name: "IX_Masalar_FirmaId",
                table: "Masalar",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Roller_FirmaId",
                table: "Roller",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Roller_RoleAdi",
                table: "Roller",
                column: "RoleAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sehirler_PlakaKodu",
                table: "Sehirler",
                column: "PlakaKodu",
                unique: true,
                filter: "[PlakaKodu] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sehirler_SehirAdi",
                table: "Sehirler",
                column: "SehirAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetaylar_FirmaId",
                table: "SiparisDetaylar",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetaylar_ID_UrunId",
                table: "SiparisDetaylar",
                columns: new[] { "ID", "UrunId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetaylar_SiparisMasterId",
                table: "SiparisDetaylar",
                column: "SiparisMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetaylar_UrunId",
                table: "SiparisDetaylar",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisMasterlar_FirmaId",
                table: "SiparisMasterlar",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisMasterlar_MasaId",
                table: "SiparisMasterlar",
                column: "MasaId",
                unique: true,
                filter: "[MasaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_FirmaId",
                table: "Urunler",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_KategoriID",
                table: "Urunler",
                column: "KategoriID");

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
                name: "Adres");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "KullaniciRole");

            migrationBuilder.DropTable(
                name: "SiparisDetaylar");

            migrationBuilder.DropTable(
                name: "Ilceler");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "SiparisMasterlar");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Sehirler");

            migrationBuilder.DropTable(
                name: "Masalar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
