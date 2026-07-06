using Ecommerce_Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce_Backend
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<Product>
    {
        public void  Configure(EntityTypeBuilder<Product> builder){
             builder.HasOne(c=>c.Category)
                    .WithMany(p=>p.Products)
                     .HasForeignKey(p=>p.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
        
        }
    }
}