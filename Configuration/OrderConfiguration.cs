using Ecommerce_Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce_Backend
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.OrderItems)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(o => o.OrderId);

            builder.Property(o => o.Status)
       .HasConversion<string>();
       builder.Property(o=>o.ShippingStatus).HasConversion<string>();
        }
    }
}