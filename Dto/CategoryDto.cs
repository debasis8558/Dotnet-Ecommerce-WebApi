using Ecommerce_Backend.Model;

namespace Ecommerce_Backend.Dto
{
    public class CategoryDto
    {
        public string? Name{get;set;}
        public ICollection<Product>? Products{get;set;}
    }
    public class CategoryResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
}