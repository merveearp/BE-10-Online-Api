using EShop.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Data.Concrete.Configs;

public class ApplicationRoleConfig: IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        var adminRole = new ApplicationRole("Yönetici rolü")
        {
            Id = "0517f36e-53b1-4a0d-b6b3-599afdd926cf",
            Name = "Admin",
            NormalizedName = "ADMIN"
        };
        var userRole = new ApplicationRole("Normal kullanıcı rolü")
        {
            Id = "c44cd475-5365-409f-845c-6ea238190b2b",
            Name = "User",
            NormalizedName = "USER"
        };
        builder.HasData(adminRole, userRole);
    }
}