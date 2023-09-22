using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class identityPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "Urunler",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Urunler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447));

            migrationBuilder.AddColumn<string>(
                name: "FirmaId",
                table: "Urunler",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "SiparisMasterlar",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "SiparisMasterlar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(8327),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 924, DateTimeKind.Local).AddTicks(4682));

            migrationBuilder.AddColumn<string>(
                name: "FirmaId",
                table: "SiparisMasterlar",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "SiparisDetaylar",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "SiparisDetaylar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(6888),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 924, DateTimeKind.Local).AddTicks(497));

            migrationBuilder.AddColumn<string>(
                name: "FirmaId",
                table: "SiparisDetaylar",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "Roller",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Roller",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(4270),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 923, DateTimeKind.Local).AddTicks(7377));

            migrationBuilder.AddColumn<string>(
                name: "FirmaId",
                table: "Roller",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "Masalar",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Masalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(9426),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 924, DateTimeKind.Local).AddTicks(7285));

            migrationBuilder.AddColumn<string>(
                name: "FirmaId",
                table: "Masalar",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "Kullanicilar",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Kullanicilar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(2703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 923, DateTimeKind.Local).AddTicks(3967));

            migrationBuilder.AddColumn<string>(
                name: "FirmaId",
                table: "Kullanicilar",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "Kategoriler",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Kategoriler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(784),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 923, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.AddColumn<string>(
                name: "FirmaId",
                table: "Kategoriler",
                type: "nvarchar(450)",
                nullable: true);

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
                name: "Ilceler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirId = table.Column<int>(type: "int", nullable: true),
                    IlceAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(1319), null, null });

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(1321), null, null });

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(1322), null, null });

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(1323), null, null });

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(1324), null, null });

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(3111), null, null });

            migrationBuilder.UpdateData(
                table: "Masalar",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(9426), null, null });

            migrationBuilder.UpdateData(
                table: "Masalar",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(9426), null, null });

            migrationBuilder.UpdateData(
                table: "Masalar",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(9426), null, null });

            migrationBuilder.UpdateData(
                table: "Roller",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(4665), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreateTime", "FirmaId", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_FirmaId",
                table: "Urunler",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisMasterlar_FirmaId",
                table: "SiparisMasterlar",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetaylar_FirmaId",
                table: "SiparisDetaylar",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Roller_FirmaId",
                table: "Roller",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Masalar_FirmaId",
                table: "Masalar",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_FirmaId",
                table: "Kullanicilar",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_FirmaId",
                table: "Kategoriler",
                column: "FirmaId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Kategoriler_AspNetUsers_FirmaId",
                table: "Kategoriler",
                column: "FirmaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicilar_AspNetUsers_FirmaId",
                table: "Kullanicilar",
                column: "FirmaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Masalar_AspNetUsers_FirmaId",
                table: "Masalar",
                column: "FirmaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roller_AspNetUsers_FirmaId",
                table: "Roller",
                column: "FirmaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisDetaylar_AspNetUsers_FirmaId",
                table: "SiparisDetaylar",
                column: "FirmaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisMasterlar_AspNetUsers_FirmaId",
                table: "SiparisMasterlar",
                column: "FirmaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_AspNetUsers_FirmaId",
                table: "Urunler",
                column: "FirmaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategoriler_AspNetUsers_FirmaId",
                table: "Kategoriler");

            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicilar_AspNetUsers_FirmaId",
                table: "Kullanicilar");

            migrationBuilder.DropForeignKey(
                name: "FK_Masalar_AspNetUsers_FirmaId",
                table: "Masalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Roller_AspNetUsers_FirmaId",
                table: "Roller");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisDetaylar_AspNetUsers_FirmaId",
                table: "SiparisDetaylar");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisMasterlar_AspNetUsers_FirmaId",
                table: "SiparisMasterlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_AspNetUsers_FirmaId",
                table: "Urunler");

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
                name: "Ilceler");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Sehirler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_FirmaId",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_SiparisMasterlar_FirmaId",
                table: "SiparisMasterlar");

            migrationBuilder.DropIndex(
                name: "IX_SiparisDetaylar_FirmaId",
                table: "SiparisDetaylar");

            migrationBuilder.DropIndex(
                name: "IX_Roller_FirmaId",
                table: "Roller");

            migrationBuilder.DropIndex(
                name: "IX_Masalar_FirmaId",
                table: "Masalar");

            migrationBuilder.DropIndex(
                name: "IX_Kullanicilar_FirmaId",
                table: "Kullanicilar");

            migrationBuilder.DropIndex(
                name: "IX_Kategoriler_FirmaId",
                table: "Kategoriler");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "SiparisMasterlar");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "SiparisDetaylar");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "Roller");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "Masalar");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "Kategoriler");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "Urunler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Urunler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 593, DateTimeKind.Local).AddTicks(831));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "SiparisMasterlar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "SiparisMasterlar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 924, DateTimeKind.Local).AddTicks(4682),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(8327));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "SiparisDetaylar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "SiparisDetaylar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 924, DateTimeKind.Local).AddTicks(497),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(6888));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "Roller",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Roller",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 923, DateTimeKind.Local).AddTicks(7377),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(4270));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "Masalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Masalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 924, DateTimeKind.Local).AddTicks(7285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(9426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "Kullanicilar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Kullanicilar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 923, DateTimeKind.Local).AddTicks(3967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(2703));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "Kategoriler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Kategoriler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 12, 20, 18, 19, 923, DateTimeKind.Local).AddTicks(176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 20, 16, 32, 56, 592, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 923, DateTimeKind.Local).AddTicks(1332), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 923, DateTimeKind.Local).AddTicks(1337), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 923, DateTimeKind.Local).AddTicks(1339), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 923, DateTimeKind.Local).AddTicks(1340), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 923, DateTimeKind.Local).AddTicks(1343), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 923, DateTimeKind.Local).AddTicks(5146), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Masalar",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 924, DateTimeKind.Local).AddTicks(7285), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Masalar",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 924, DateTimeKind.Local).AddTicks(7285), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Masalar",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 924, DateTimeKind.Local).AddTicks(7285), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Roller",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 923, DateTimeKind.Local).AddTicks(8298), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 18, 19, 925, DateTimeKind.Local).AddTicks(447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
