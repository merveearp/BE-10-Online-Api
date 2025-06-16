using EShop.Entity.Concrete;
using EShop.Shared.ComplexTypes;
using Microsoft.EntityFrameworkCore;

namespace EShop.Data.Concrete.Extensions;

public static class ModelBuilderExtensions
{
    public static void SeedData(this ModelBuilder builder)
    {
        builder.Entity<OrderItem>().Property(x => x.UnitPrice).HasColumnType("decimal(10,2)");
        builder.Entity<OrderItem>().HasQueryFilter(x => !x.IsDeleted);
        builder.Entity<Order>().HasQueryFilter(x => !x.IsDeleted);

        var orders = new List<Order>();
        var orderItems = new List<OrderItem>();

        var userIds = new List<string>
        {
            "d4757375-a497-496b-85dc-a510027bd9b1",
            "d2fe392f-4f60-4963-ba3a-ea52b71fb53e"
        };

        Random random = new();
        DateTime startDate = new(2024, 9, 1);
        DateTime endDate = new(2025, 2, 20);
        int range = (endDate - startDate).Days;
        int orderItemId = 1;

        for (int i = 1; i <= 20; i++)
        {
            var order = new Order(
                userIds[random.Next(0, userIds.Count)],
                $"Address {i}",
                $"City {i % 5 + 1}"
            )
            {
                Id = i,
                CreatedAt = startDate.AddDays(random.Next(range)),
                OrderStatus = i <= 10 ? OrderStatus.Delivered : (OrderStatus)random.Next(0, 3)
            };

            orders.Add(order);

            int itemCount = random.Next(1, 6);

            for (int j = 1; j <= itemCount; j++)
            {
                int productId = random.Next(1, 41);
                decimal unitPrice = random.Next(10, 501);
                int quantity = random.Next(1, 6);

                var orderItem = new OrderItem(order.Id, productId, unitPrice, quantity)
                {
                    Id = orderItemId,
                    OrderId = i // Order'ın foreign key'ini burada belirtiyoruz
                };

                orderItems.Add(orderItem);
                orderItemId++;
            }
        }

        builder.Entity<Order>().HasData(orders);
        builder.Entity<OrderItem>().HasData(orderItems);
            
    }
}