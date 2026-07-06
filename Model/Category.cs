using Ecommerce_Backend.Model;

namespace Ecommerce_Backend
{
    public class Category:BaseEntity
    {
        public int Id{get;set;}
        public string? Name{get;set;}
        public ICollection<Product>? Products{get;set;}
    }
}