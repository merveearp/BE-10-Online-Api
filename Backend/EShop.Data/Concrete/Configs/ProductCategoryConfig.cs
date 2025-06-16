using EShop.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Data.Concrete.Configs;

public class ProductCategoryConfig:IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(x => new { x.ProductId, x.CategoryId });
        //Product=>ProductCategory 1e Çok İlişki
        builder
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId);
        //Category=>ProductCategory 1e Çok İlişki
        builder
            .HasOne(pc => pc.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(pc => pc.CategoryId);

        builder.HasQueryFilter(x => !x.Category!.IsDeleted && !x.Product!.IsDeleted);

        builder.HasData(
            // Elektronik Kategorisi (Id:1) İlişkileri
            new ProductCategory(1, 1),   // Dizüstü Bilgisayar
            new ProductCategory(2, 1),   // Akıllı Telefon
            new ProductCategory(3, 1),   // Tablet
            new ProductCategory(4, 1),   // Akıllı Saat → Elektronik
            new ProductCategory(5, 1),   // Kablosuz Kulaklık

            // Moda Kategorisi (Id:2) İlişkileri
            new ProductCategory(6, 2),   // Erkek Ceket
            new ProductCategory(7, 2),   // Kadın Elbise
            new ProductCategory(8, 2),   // Spor Ayakkabı → Moda
            new ProductCategory(9, 2),   // Çanta → Moda
            new ProductCategory(10, 2),  // Güneş Gözlüğü

            // Ev & Yaşam Kategorisi (Id:3) İlişkileri
            new ProductCategory(11, 3),  // Yemek Takımı
            new ProductCategory(12, 3),  // Kanepe
            new ProductCategory(13, 3),  // Yatak Örtüsü
            new ProductCategory(14, 3),  // Masa Lambası
            new ProductCategory(15, 3),  // Süpürge

            // Spor & Outdoor Kategorisi (Id:4) İlişkileri
            new ProductCategory(4, 4),   // Akıllı Saat → Spor & Outdoor
            new ProductCategory(8, 4),   // Spor Ayakkabı → Spor & Outdoor
            new ProductCategory(16, 4),  // Spor Çantası → Spor & Outdoor
            new ProductCategory(17, 4),  // Tent
            new ProductCategory(18, 4),  // Bisiklet
            new ProductCategory(19, 4),  // Koşu Bandı
            new ProductCategory(20, 4),  // Spor Eldiveni
            new ProductCategory(39, 4),  // Çocuk Bisikleti → Spor & Outdoor

            // Kitap & Dergi Kategorisi (Id:5) İlişkileri
            new ProductCategory(21, 5),  // Roman Kitabı
            new ProductCategory(22, 5),  // Kişisel Gelişim Kitabı
            new ProductCategory(23, 5),  // Bilim Kurgu Kitabı
            new ProductCategory(24, 5),  // Dergi
            new ProductCategory(25, 5),  // Çocuk Kitabı → Kitap & Dergi

            // Oyuncak & Hobi Kategorisi (Id:6) İlişkileri
            new ProductCategory(26, 6),  // Lego Seti → Oyuncak & Hobi
            new ProductCategory(27, 6),  // Model Uçak
            new ProductCategory(28, 6),  // Puzzle
            new ProductCategory(29, 6),  // Boyama Kitabı
            new ProductCategory(30, 6),  // RC Araba → Oyuncak & Hobi
            new ProductCategory(38, 6),  // Oyuncak Bebek → Oyuncak & Hobi

            // Kozmetik & Bakım Kategorisi (Id:7) İlişkileri
            new ProductCategory(31, 7),  // Nemlendirici Krem
            new ProductCategory(32, 7),  // Ruj
            new ProductCategory(33, 7),  // Parfüm
            new ProductCategory(34, 7),  // Şampuan
            new ProductCategory(35, 7),  // Tıraş Makinesi

            // Bebek & Çocuk Kategorisi (Id:9) İlişkileri
            new ProductCategory(25, 9),  // Çocuk Kitabı → Bebek & Çocuk
            new ProductCategory(26, 9),  // Lego Seti → Bebek & Çocuk
            new ProductCategory(30, 9),  // RC Araba → Bebek & Çocuk
            new ProductCategory(36, 9),  // Bebek Bezi
            new ProductCategory(37, 9),  // Bebek Arabası
            new ProductCategory(38, 9),  // Oyuncak Bebek → Bebek & Çocuk
            new ProductCategory(39, 9),  // Çocuk Bisikleti → Bebek & Çocuk
            new ProductCategory(40, 9),  // Bebek Giysisi → Bebek & Çocuk

            // Çapraz İlişkiler
            new ProductCategory(9, 3),   // Çanta → Ev & Yaşam
            new ProductCategory(16, 2),  // Spor Çantası → Moda
            new ProductCategory(40, 2)   // Bebek Giysisi → Moda
        );
    }
}