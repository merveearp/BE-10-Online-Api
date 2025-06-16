using EShop.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Data.Concrete.Configs;

public class CartConfig: IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasQueryFilter(x => !x.IsDeleted);
        

        builder.HasData(
            new Cart("d2fe392f-4f60-4963-ba3a-ea52b71fb53e") { Id = 1 },
            new Cart("d4757375-a497-496b-85dc-a510027bd9b1") { Id = 2 }
        );
    }
}