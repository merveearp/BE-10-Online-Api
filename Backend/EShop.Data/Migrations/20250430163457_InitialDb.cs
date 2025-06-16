using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsMenuItem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0517f36e-53b1-4a0d-b6b3-599afdd926cf", null, "Yönetici rolü", "Admin", "ADMIN" },
                    { "c44cd475-5365-409f-845c-6ea238190b2b", null, "Normal kullanıcı rolü", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", 0, "Kadıköy", "İstanbul", "23e0e78a-cbc8-4388-9fa3-bf4bce03f72a", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testuser@gmail.com", true, "Esin", 2, "Çelik", false, null, "TESTUSER@GMAIL.COM", "TESTUSER", "AQAAAAIAAYagAAAAENqe/3NfkdDMPBCHZCWvBDiIrPy3RiZOlni+i4GHarvk16rVU6mSA90iFb6qkPCqew==", null, false, "6eee1fd0-a0e9-410e-8848-6ddf77641ad0", false, "testuser" },
                    { "d4757375-a497-496b-85dc-a510027bd9b1", 0, "Ataşehir", "İstanbul", "e50f3e57-a580-488f-8364-bdfda9c59a30", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testadmin@gmail.com", true, "Ali", 3, "Cabbar", false, null, "TESTADMIN@GMAIL.COM", "TESTADMIN", "AQAAAAIAAYagAAAAEIQEnlp8VSu8wV7Iro7nZnZverxgW7gvkenAwKJj7QeqmSoPMqEyTr837XRgcOXEUQ==", null, false, "7e73ea42-7b40-4d48-83ea-9b2e571d9739", false, "testadmin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "ImageUrl", "IsActive", "IsDeleted", "IsMenuItem", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6670), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bilgisayarlar, akıllı telefonlar, tabletler, televizyonlar ve diğer tüm elektronik cihazlar bu kategoride bulunabilir. Teknoloji tutkunları için en yeni ve popüler ürünler burada!", "/images/categories/elektronik.png", true, false, true, "Elektronik", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6680), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6680), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Kadın, erkek ve çocuk giyim ürünleri, ayakkabılar, çantalar ve aksesuarlar bu kategoride. Trendleri yakalayın ve tarzınızı yansıtın!", "/images/categories/moda.png", true, false, true, "Moda", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6680), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6680), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Ev dekorasyonu, mobilyalar, mutfak gereçleri, bahçe ürünleri ve daha fazlası bu kategoride. Evinizi güzelleştirmek için ihtiyacınız olan her şey burada!", "/images/categories/ev-yasam.png", true, false, true, "Ev & Yaşam", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6680), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6680), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Spor ekipmanları, outdoor giyim, kamp malzemeleri, bisikletler ve fitness ürünleri bu kategoride. Aktif bir yaşam için ihtiyacınız olan her şey burada!", "/images/categories/spor-outdoor.png", true, false, true, "Spor & Outdoor", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6680), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6680), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Romanlar, kişisel gelişim kitapları, akademik yayınlar, dergiler ve daha fazlası bu kategoride. Okuma tutkunları için geniş bir seçki!", "/images/categories/kitap-dergi.png", true, false, true, "Kitap & Dergi", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Çocuk oyuncakları, yapbozlar, model kitler, hobi malzemeleri ve koleksiyon ürünleri bu kategoride. Hem çocuklar hem de yetişkinler için eğlenceli seçenekler!", "/images/categories/oyuncak-hobi.png", true, false, false, "Oyuncak & Hobi", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Cilt bakım ürünleri, makyaj malzemeleri, parfümler, saç bakım ürünleri ve daha fazlası bu kategoride. Kendinizi şımartın ve bakım rutininizi oluşturun!", "/images/categories/kozmetik-bakim.png", true, false, false, "Kozmetik & Kişisel Bakım", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Valizler, sırt çantaları, seyahat aksesuarları ve seyahat planlaması için gerekli ürünler bu kategoride. Yeni yerler keşfetmeye hazır olun!", "/images/categories/seyahat-valiz.png", false, false, false, "Seyahat & Valiz", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bebek giysileri, bebek bakım ürünleri, oyuncaklar, çocuk odası dekorasyonu ve daha fazlası bu kategoride. Bebekler ve çocuklar için en kaliteli ürünler!", "/images/categories/bebek-cocuk.png", true, false, false, "Bebek & Çocuk", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Araç bakım ürünleri, yedek parçalar, araç içi aksesuarlar ve otomotiv ekipmanları bu kategoride. Araç tutkunları için ihtiyaç duyulan her şey!", "/images/categories/otomotiv.png", false, false, false, "Otomotiv", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(6690), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ImageUrl", "IsActive", "IsDeleted", "IsHome", "Name", "Price", "Properties", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(120), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/laptop.png", true, false, true, "Dizüstü Bilgisayar", 1500.00m, "16GB RAM, 512GB SSD, Intel i7 İşlemci", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(120), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(120), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/smartphone.png", true, false, false, "Akıllı Telefon", 800.00m, "128GB Depolama, 6GB RAM, 5G Desteği", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/tablet.png", true, false, false, "Tablet", 600.00m, "10.5 inç Ekran, 256GB Depolama, Kalem Desteği", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/smartwatch.png", true, false, false, "Akıllı Saat", 250.00m, "GPS, Kalp Atışı Ölçer, Suya Dayanıklı", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/earbuds.png", false, false, false, "Kablosuz Kulaklık", 150.00m, "Gürültü Önleyici, 20 Saat Pil Ömrü", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/men-jacket.png", true, false, true, "Erkek Ceket", 120.00m, "Slim Fit, Kumaş Ceket", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/women-dress.png", true, false, false, "Kadın Elbise", 80.00m, "Yazlık Desenli, Pamuklu", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/sneakers.png", true, false, false, "Spor Ayakkabı", 90.00m, "Hafif, Nefes Alabilir Taban", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(130), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/bag.png", true, false, false, "Çanta", 70.00m, "Deri, Günlük Kullanım", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/sunglasses.png", false, false, false, "Güneş Gözlüğü", 50.00m, "UV Koruma, Polarize Cam", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 11, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/dinner-set.png", true, false, true, "Yemek Takımı", 100.00m, "12 Parça, Porselen", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 12, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/sofa.png", true, false, false, "Kanepe", 500.00m, "3 Kişilik, Kumaş Kaplama", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 13, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/bed-sheet.png", true, false, false, "Yatak Örtüsü", 60.00m, "Pamuklu, 200x220 cm", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 14, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/lamp.png", true, false, false, "Masa Lambası", 40.00m, "LED, Ayarlanabilir Işık", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 15, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/vacuum.png", false, false, false, "Süpürge", 120.00m, "Elektrikli, HEPA Filtre", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 16, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/gym-bag.png", true, false, true, "Spor Çantası", 45.00m, "30 Litre, Çok Bölmeli", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 17, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/tent.png", true, false, false, "Tent", 200.00m, "4 Kişilik, Su Geçirmez", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 18, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/bike.png", true, false, false, "Bisiklet", 350.00m, "21 Vites, Dağ Bisikleti", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 19, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/treadmill.png", true, false, false, "Koşu Bandı", 600.00m, "Katlanabilir, 12 Program", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 20, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/gloves.png", false, false, false, "Spor Eldiveni", 25.00m, "Antrenman için, Ergonomik", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 21, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/novel.png", true, false, true, "Roman Kitabı", 20.00m, "En Çok Satanlar Listesinden", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 22, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/self-help.png", true, false, false, "Kişisel Gelişim Kitabı", 25.00m, "Motivasyon ve Başarı İçin", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 23, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/sci-fi.png", true, false, false, "Bilim Kurgu Kitabı", 30.00m, "Klasik Bilim Kurgu Eseri", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 24, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/magazine.png", true, false, false, "Dergi", 10.00m, "Aylık Teknoloji Dergisi", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 25, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/kids-book.png", false, false, false, "Çocuk Kitabı", 15.00m, "Resimli, Eğitici Hikayeler", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 26, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/lego.png", true, false, true, "Lego Seti", 80.00m, "1000 Parça, Yaratıcı Set", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 27, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(160), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/model-plane.png", true, false, false, "Model Uçak", 50.00m, "1:100 Ölçekli, Detaylı", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 28, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/puzzle.png", true, false, false, "Puzzle", 30.00m, "1000 Parça, Manzara Temalı", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 29, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/coloring-book.png", true, false, false, "Boyama Kitabı", 20.00m, "Yetişkinler İçin Mandala", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 30, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/rc-car.png", true, false, false, "RC Araba", 70.00m, "Uzaktan Kumandalı, Hızlı", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 31, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/moisturizer.png", true, false, true, "Nemlendirici Krem", 40.00m, "Cilt Bariyerini Güçlendirir", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 32, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/lipstick.png", true, false, false, "Ruj", 25.00m, "Uzun Süre Kalıcı, 12 Renk Seçeneği", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 33, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/perfume.png", true, false, false, "Parfüm", 60.00m, "100 ml, Günlük Kullanım", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 34, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/shampoo.png", true, false, false, "Şampuan", 15.00m, "Saç Dökülmesine Karşı Etkili", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 35, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/razor.png", true, false, false, "Tıraş Makinesi", 90.00m, "Islak & Kuru Kullanım", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 36, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/diapers.png", true, false, true, "Bebek Bezi", 40.00m, "Hipoalerjenik, 120 Adet", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 37, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/stroller.png", true, false, false, "Bebek Arabası", 200.00m, "Katlanabilir, Hafif", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 38, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/doll.png", true, false, false, "Oyuncak Bebek", 35.00m, "Gerçekçi Tasarım, 30 cm", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 39, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/kids-bike.png", true, false, false, "Çocuk Bisikleti", 100.00m, "12 inç, Yardımcı Tekerlekli", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 40, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/images/products/baby-clothes.png", true, false, false, "Bebek Giysisi", 20.00m, "Pamuklu, Rahat", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 824, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c44cd475-5365-409f-845c-6ea238190b2b", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e" },
                    { "0517f36e-53b1-4a0d-b6b3-599afdd926cf", "d4757375-a497-496b-85dc-a510027bd9b1" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(5500), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, "d4757375-a497-496b-85dc-a510027bd9b1", new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 823, DateTimeKind.Unspecified).AddTicks(5510), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "ApplicationUserId", "City", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "OrderStatus", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Address 1", "d4757375-a497-496b-85dc-a510027bd9b1", "City 2", new DateTimeOffset(new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, "Address 2", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 3", new DateTimeOffset(new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, "Address 3", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 4", new DateTimeOffset(new DateTime(2024, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, "Address 4", "d4757375-a497-496b-85dc-a510027bd9b1", "City 5", new DateTimeOffset(new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, "Address 5", "d4757375-a497-496b-85dc-a510027bd9b1", "City 1", new DateTimeOffset(new DateTime(2024, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, "Address 6", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 2", new DateTimeOffset(new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, "Address 7", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 3", new DateTimeOffset(new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, "Address 8", "d4757375-a497-496b-85dc-a510027bd9b1", "City 4", new DateTimeOffset(new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, "Address 9", "d4757375-a497-496b-85dc-a510027bd9b1", "City 5", new DateTimeOffset(new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, "Address 10", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 1", new DateTimeOffset(new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 11, "Address 11", "d4757375-a497-496b-85dc-a510027bd9b1", "City 2", new DateTimeOffset(new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 12, "Address 12", "d4757375-a497-496b-85dc-a510027bd9b1", "City 3", new DateTimeOffset(new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 13, "Address 13", "d4757375-a497-496b-85dc-a510027bd9b1", "City 4", new DateTimeOffset(new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 14, "Address 14", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", "City 5", new DateTimeOffset(new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 15, "Address 15", "d4757375-a497-496b-85dc-a510027bd9b1", "City 1", new DateTimeOffset(new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 16, "Address 16", "d4757375-a497-496b-85dc-a510027bd9b1", "City 2", new DateTimeOffset(new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 17, "Address 17", "d4757375-a497-496b-85dc-a510027bd9b1", "City 3", new DateTimeOffset(new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 18, "Address 18", "d4757375-a497-496b-85dc-a510027bd9b1", "City 4", new DateTimeOffset(new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 19, "Address 19", "d4757375-a497-496b-85dc-a510027bd9b1", "City 5", new DateTimeOffset(new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 20, "Address 20", "d4757375-a497-496b-85dc-a510027bd9b1", "City 1", new DateTimeOffset(new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 4, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 4, 8 },
                    { 2, 9 },
                    { 3, 9 },
                    { 2, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 14 },
                    { 3, 15 },
                    { 2, 16 },
                    { 4, 16 },
                    { 4, 17 },
                    { 4, 18 },
                    { 4, 19 },
                    { 4, 20 },
                    { 5, 21 },
                    { 5, 22 },
                    { 5, 23 },
                    { 5, 24 },
                    { 5, 25 },
                    { 9, 25 },
                    { 6, 26 },
                    { 9, 26 },
                    { 6, 27 },
                    { 6, 28 },
                    { 6, 29 },
                    { 6, 30 },
                    { 9, 30 },
                    { 7, 31 },
                    { 7, 32 },
                    { 7, 33 },
                    { 7, 34 },
                    { 7, 35 },
                    { 9, 36 },
                    { 9, 37 },
                    { 6, 38 },
                    { 9, 38 },
                    { 4, 39 },
                    { 9, 39 },
                    { 2, 40 },
                    { 9, 40 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "OrderId", "ProductId", "Quantity", "UnitPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6270), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 1, 17, 1, 146m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6280), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 1, 5, 2, 388m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6280), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 1, 8, 5, 94m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6290), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, 9, 4, 129m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6290), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, 39, 3, 286m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6290), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, 4, 1, 419m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6290), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 2, 34, 5, 469m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6300), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 3, 39, 2, 352m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6300), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 4, 25, 5, 432m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6300), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 4, 11, 1, 261m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 11, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6310), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 4, 27, 2, 395m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 12, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6310), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 4, 25, 1, 280m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 13, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6310), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 5, 6, 3, 437m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 14, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6310), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 5, 3, 1, 127m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 15, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6310), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 5, 34, 5, 165m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 16, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6320), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 6, 24, 5, 197m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 17, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6320), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 7, 19, 4, 121m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 18, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6320), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 7, 14, 2, 377m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 19, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6330), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 7, 37, 2, 46m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 20, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6330), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 8, 22, 1, 248m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 21, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6330), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 8, 32, 5, 228m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 22, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6330), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 8, 33, 4, 394m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 23, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6330), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 8, 21, 1, 362m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 24, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6340), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 9, 1, 4, 314m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 25, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6340), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 9, 7, 5, 430m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 26, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6340), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 10, 28, 5, 259m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 27, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6350), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 11, 39, 4, 337m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 28, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6350), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 11, 11, 5, 264m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 29, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6350), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 11, 11, 1, 456m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 30, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6360), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 12, 40, 4, 285m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 31, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6360), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 12, 24, 1, 491m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 32, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6360), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 13, 25, 4, 429m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 33, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6360), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 13, 13, 4, 198m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 34, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 13, 17, 5, 436m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 35, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 13, 15, 2, 305m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 36, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 14, 26, 1, 238m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 37, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 14, 7, 5, 374m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 38, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6390), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 15, 15, 2, 67m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 39, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6390), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 15, 37, 2, 201m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 40, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6390), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 15, 19, 3, 37m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 41, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6390), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 15, 33, 2, 296m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 42, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6400), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 16, 36, 5, 249m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 43, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6400), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 16, 17, 1, 35m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 44, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6400), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 17, 22, 3, 472m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 45, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6410), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 18, 24, 2, 368m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 46, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6410), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 19, 31, 1, 263m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 47, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6420), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 19, 27, 4, 444m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 48, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6420), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 19, 36, 4, 261m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 49, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6420), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 19, 8, 2, 422m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 50, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6420), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 20, 12, 5, 60m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 51, new DateTimeOffset(new DateTime(2025, 4, 30, 16, 34, 56, 751, DateTimeKind.Unspecified).AddTicks(6420), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, false, 20, 24, 5, 415m, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

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
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ApplicationUserId",
                table: "Carts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
