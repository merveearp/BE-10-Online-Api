using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Data.Concrete.Configs;

public class UserRoleConfig:IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "0517f36e-53b1-4a0d-b6b3-599afdd926cf",
                UserId = "d4757375-a497-496b-85dc-a510027bd9b1"
            },
            new IdentityUserRole<string>
            {
                RoleId = "c44cd475-5365-409f-845c-6ea238190b2b",
                UserId = "d2fe392f-4f60-4963-ba3a-ea52b71fb53e"
            }
        );
    }
}