using EShop.Entity.Concrete;
using EShop.Shared.ComplexTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Data.Concrete.Configs;

public class ApplicationUserConfig: IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        var adminUser = new ApplicationUser("Ali", "Cabbar", new DateTime(1995, 1, 1), Gender.Male)
        {
            Id = "d4757375-a497-496b-85dc-a510027bd9b1",
            UserName = "testadmin",
            NormalizedUserName = "TESTADMIN",
            Email = "testadmin@gmail.com",
            NormalizedEmail = "TESTADMIN@GMAIL.COM",
            EmailConfirmed = true,
            Address = "Ataşehir",
            City = "İstanbul"
        };
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Qwe123.,");


        var normalUser = new ApplicationUser("Esin", "Çelik", new DateTime(1995, 1, 1), Gender.Female)
        {
            Id = "d2fe392f-4f60-4963-ba3a-ea52b71fb53e",
            UserName = "testuser",
            NormalizedUserName = "TESTUSER",
            Email = "testuser@gmail.com",
            NormalizedEmail = "TESTUSER@GMAIL.COM",
            EmailConfirmed = true,
            Address = "Kadıköy",
            City = "İstanbul"
        };
        normalUser.PasswordHash = hasher.HashPassword(normalUser, "Qwe123.,");


        builder.HasData(adminUser, normalUser);
    }
}