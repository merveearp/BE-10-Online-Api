using EShop.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Data.Concrete.Configs;

public class ProductConfig:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(10,2)");
        builder.Property(p => p.ImageUrl).IsRequired();

        builder.HasData(
            // Elektronik Kategorisi (Id: 1)
            new Product("Dizüstü Bilgisayar", "16GB RAM, 512GB SSD, Intel i7 İşlemci", 1500.00m, "/images/products/laptop.png") { Id = 1, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow, IsHome=true }, // Kategoriler: Elektronik
            new Product("Akıllı Telefon", "128GB Depolama, 6GB RAM, 5G Desteği", 800.00m, "/images/products/smartphone.png") { Id = 2, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Elektronik
            new Product("Tablet", "10.5 inç Ekran, 256GB Depolama, Kalem Desteği", 600.00m, "/images/products/tablet.png") { Id = 3, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Elektronik
            new Product("Akıllı Saat", "GPS, Kalp Atışı Ölçer, Suya Dayanıklı", 250.00m, "/images/products/smartwatch.png") { Id = 4, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Elektronik, Spor & Outdoor
            new Product("Kablosuz Kulaklık", "Gürültü Önleyici, 20 Saat Pil Ömrü", 150.00m, "/images/products/earbuds.png") { Id = 5, IsActive = false, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Elektronik (Pasif)

            // Moda Kategorisi (Id: 2)
            new Product("Erkek Ceket", "Slim Fit, Kumaş Ceket", 120.00m, "/images/products/men-jacket.png") { Id = 6, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow, IsHome=true }, // Kategoriler: Moda
            new Product("Kadın Elbise", "Yazlık Desenli, Pamuklu", 80.00m, "/images/products/women-dress.png") { Id = 7, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Moda
            new Product("Spor Ayakkabı", "Hafif, Nefes Alabilir Taban", 90.00m, "/images/products/sneakers.png") { Id = 8, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Moda, Spor & Outdoor
            new Product("Çanta", "Deri, Günlük Kullanım", 70.00m, "/images/products/bag.png") { Id = 9, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Moda, Ev & Yaşam
            new Product("Güneş Gözlüğü", "UV Koruma, Polarize Cam", 50.00m, "/images/products/sunglasses.png") { Id = 10, IsActive = false, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Moda (Pasif)

            // Ev & Yaşam Kategorisi (Id: 3)
            new Product("Yemek Takımı", "12 Parça, Porselen", 100.00m, "/images/products/dinner-set.png") { Id = 11, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow, IsHome=true }, // Kategoriler: Ev & Yaşam
            new Product("Kanepe", "3 Kişilik, Kumaş Kaplama", 500.00m, "/images/products/sofa.png") { Id = 12, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Ev & Yaşam
            new Product("Yatak Örtüsü", "Pamuklu, 200x220 cm", 60.00m, "/images/products/bed-sheet.png") { Id = 13, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Ev & Yaşam
            new Product("Masa Lambası", "LED, Ayarlanabilir Işık", 40.00m, "/images/products/lamp.png") { Id = 14, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Ev & Yaşam
            new Product("Süpürge", "Elektrikli, HEPA Filtre", 120.00m, "/images/products/vacuum.png") { Id = 15, IsActive = false, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Ev & Yaşam (Pasif)

            // Spor & Outdoor Kategorisi (Id: 4)
            new Product("Spor Çantası", "30 Litre, Çok Bölmeli", 45.00m, "/images/products/gym-bag.png") { Id = 16, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow, IsHome=true }, // Kategoriler: Spor & Outdoor, Moda
            new Product("Tent", "4 Kişilik, Su Geçirmez", 200.00m, "/images/products/tent.png") { Id = 17, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Spor & Outdoor
            new Product("Bisiklet", "21 Vites, Dağ Bisikleti", 350.00m, "/images/products/bike.png") { Id = 18, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Spor & Outdoor
            new Product("Koşu Bandı", "Katlanabilir, 12 Program", 600.00m, "/images/products/treadmill.png") { Id = 19, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Spor & Outdoor
            new Product("Spor Eldiveni", "Antrenman için, Ergonomik", 25.00m, "/images/products/gloves.png") { Id = 20, IsActive = false, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Spor & Outdoor (Pasif)

            // Kitap & Dergi Kategorisi (Id: 5)
            new Product("Roman Kitabı", "En Çok Satanlar Listesinden", 20.00m, "/images/products/novel.png") { Id = 21, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow, IsHome=true }, // Kategoriler: Kitap & Dergi
            new Product("Kişisel Gelişim Kitabı", "Motivasyon ve Başarı İçin", 25.00m, "/images/products/self-help.png") { Id = 22, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Kitap & Dergi
            new Product("Bilim Kurgu Kitabı", "Klasik Bilim Kurgu Eseri", 30.00m, "/images/products/sci-fi.png") { Id = 23, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Kitap & Dergi
            new Product("Dergi", "Aylık Teknoloji Dergisi", 10.00m, "/images/products/magazine.png") { Id = 24, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Kitap & Dergi
            new Product("Çocuk Kitabı", "Resimli, Eğitici Hikayeler", 15.00m, "/images/products/kids-book.png") { Id = 25, IsActive = false, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Kitap & Dergi, Bebek & Çocuk (Pasif)

            // Oyuncak & Hobi Kategorisi (Id: 6)
            new Product("Lego Seti", "1000 Parça, Yaratıcı Set", 80.00m, "/images/products/lego.png") { Id = 26, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow, IsHome=true }, // Kategoriler: Oyuncak & Hobi, Bebek & Çocuk
            new Product("Model Uçak", "1:100 Ölçekli, Detaylı", 50.00m, "/images/products/model-plane.png") { Id = 27, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Oyuncak & Hobi
            new Product("Puzzle", "1000 Parça, Manzara Temalı", 30.00m, "/images/products/puzzle.png") { Id = 28, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Oyuncak & Hobi
            new Product("Boyama Kitabı", "Yetişkinler İçin Mandala", 20.00m, "/images/products/coloring-book.png") { Id = 29, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Oyuncak & Hobi
            new Product("RC Araba", "Uzaktan Kumandalı, Hızlı", 70.00m, "/images/products/rc-car.png") { Id = 30, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Oyuncak & Hobi, Bebek & Çocuk

            // Kozmetik & Kişisel Bakım Kategorisi (Id: 7)
            new Product("Nemlendirici Krem", "Cilt Bariyerini Güçlendirir", 40.00m, "/images/products/moisturizer.png") { Id = 31, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow, IsHome=true }, // Kategoriler: Kozmetik & Bakım
            new Product("Ruj", "Uzun Süre Kalıcı, 12 Renk Seçeneği", 25.00m, "/images/products/lipstick.png") { Id = 32, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Kozmetik & Bakım
            new Product("Parfüm", "100 ml, Günlük Kullanım", 60.00m, "/images/products/perfume.png") { Id = 33, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Kozmetik & Bakım
            new Product("Şampuan", "Saç Dökülmesine Karşı Etkili", 15.00m, "/images/products/shampoo.png") { Id = 34, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Kozmetik & Bakım
            new Product("Tıraş Makinesi", "Islak & Kuru Kullanım", 90.00m, "/images/products/razor.png") { Id = 35, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Kozmetik & Bakım

            // Bebek & Çocuk Kategorisi (Id: 9)
            new Product("Bebek Bezi", "Hipoalerjenik, 120 Adet", 40.00m, "/images/products/diapers.png") { Id = 36, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow, IsHome=true }, // Kategoriler: Bebek & Çocuk
            new Product("Bebek Arabası", "Katlanabilir, Hafif", 200.00m, "/images/products/stroller.png") { Id = 37, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Bebek & Çocuk
            new Product("Oyuncak Bebek", "Gerçekçi Tasarım, 30 cm", 35.00m, "/images/products/doll.png") { Id = 38, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Bebek & Çocuk, Oyuncak & Hobi
            new Product("Çocuk Bisikleti", "12 inç, Yardımcı Tekerlekli", 100.00m, "/images/products/kids-bike.png") { Id = 39, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow }, // Kategoriler: Bebek & Çocuk, Spor & Outdoor
            new Product("Bebek Giysisi", "Pamuklu, Rahat", 20.00m, "/images/products/baby-clothes.png") { Id = 40, IsActive = true, IsDeleted = false, UpdatedAt = DateTime.UtcNow } // Kategoriler: Bebek & Çocuk, Moda
        );

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}