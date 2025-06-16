using EShop.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Data.Concrete.Configs;

public class CategoryConfig:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Description).HasMaxLength(500);

        builder.HasData(
            new Category("Elektronik", "/images/categories/elektronik.png")
            {
                Id = 1,
                Description = "Bilgisayarlar, akıllı telefonlar, tabletler, televizyonlar ve diğer tüm elektronik cihazlar bu kategoride bulunabilir. Teknoloji tutkunları için en yeni ve popüler ürünler burada!",
                IsActive = true,
                IsDeleted = false,
                IsMenuItem = true,
                UpdatedAt = DateTime.UtcNow
            },
            new Category("Moda", "/images/categories/moda.png")
            {
                Id = 2,
                Description = "Kadın, erkek ve çocuk giyim ürünleri, ayakkabılar, çantalar ve aksesuarlar bu kategoride. Trendleri yakalayın ve tarzınızı yansıtın!",
                IsActive = true,
                IsDeleted = false,
                IsMenuItem = true,
                UpdatedAt = DateTime.UtcNow
            },
            new Category("Ev & Yaşam", "/images/categories/ev-yasam.png")
            {
                Id = 3,
                Description = "Ev dekorasyonu, mobilyalar, mutfak gereçleri, bahçe ürünleri ve daha fazlası bu kategoride. Evinizi güzelleştirmek için ihtiyacınız olan her şey burada!",
                IsActive = true,
                IsDeleted = false,
                IsMenuItem = true,
                UpdatedAt = DateTime.UtcNow
            },
            new Category("Spor & Outdoor", "/images/categories/spor-outdoor.png")
            {
                Id = 4,
                Description = "Spor ekipmanları, outdoor giyim, kamp malzemeleri, bisikletler ve fitness ürünleri bu kategoride. Aktif bir yaşam için ihtiyacınız olan her şey burada!",
                IsActive = true,
                IsDeleted = false,
                IsMenuItem = true,
                UpdatedAt = DateTime.UtcNow
            },
            new Category("Kitap & Dergi", "/images/categories/kitap-dergi.png")
            {
                Id = 5,
                Description = "Romanlar, kişisel gelişim kitapları, akademik yayınlar, dergiler ve daha fazlası bu kategoride. Okuma tutkunları için geniş bir seçki!",
                IsActive = true,
                IsDeleted = false,
                IsMenuItem = true,
                UpdatedAt = DateTime.UtcNow
            },
            new Category("Oyuncak & Hobi", "/images/categories/oyuncak-hobi.png")
            {
                Id = 6,
                Description = "Çocuk oyuncakları, yapbozlar, model kitler, hobi malzemeleri ve koleksiyon ürünleri bu kategoride. Hem çocuklar hem de yetişkinler için eğlenceli seçenekler!",
                IsActive = true,
                IsDeleted = false,
                UpdatedAt = DateTime.UtcNow
            },
            new Category("Kozmetik & Kişisel Bakım", "/images/categories/kozmetik-bakim.png")
            {
                Id = 7,
                Description = "Cilt bakım ürünleri, makyaj malzemeleri, parfümler, saç bakım ürünleri ve daha fazlası bu kategoride. Kendinizi şımartın ve bakım rutininizi oluşturun!",
                IsActive = true,
                IsDeleted = false,
                UpdatedAt = DateTime.UtcNow
            },
            new Category("Seyahat & Valiz", "/images/categories/seyahat-valiz.png")
            {
                Id = 8,
                Description = "Valizler, sırt çantaları, seyahat aksesuarları ve seyahat planlaması için gerekli ürünler bu kategoride. Yeni yerler keşfetmeye hazır olun!",
                IsActive = false, // Bu kategori pasif
                IsDeleted = false,
                UpdatedAt = DateTime.UtcNow
            },
            new Category("Bebek & Çocuk", "/images/categories/bebek-cocuk.png")
            {
                Id = 9,
                Description = "Bebek giysileri, bebek bakım ürünleri, oyuncaklar, çocuk odası dekorasyonu ve daha fazlası bu kategoride. Bebekler ve çocuklar için en kaliteli ürünler!",
                IsActive = true,
                IsDeleted = false,
                UpdatedAt = DateTime.UtcNow
            },
            new Category("Otomotiv", "/images/categories/otomotiv.png")
            {
                Id = 10,
                Description = "Araç bakım ürünleri, yedek parçalar, araç içi aksesuarlar ve otomotiv ekipmanları bu kategoride. Araç tutkunları için ihtiyaç duyulan her şey!",
                IsActive = false, // Bu kategori pasif
                IsDeleted = false,
                UpdatedAt = DateTime.UtcNow
            }
        );

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}