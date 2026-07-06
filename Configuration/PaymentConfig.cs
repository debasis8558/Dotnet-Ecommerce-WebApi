using Ecommerce_Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce_Backend
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>

    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {

            builder.Property(p => p.Status)
                   .HasConversion<string>();


        }

    }
}