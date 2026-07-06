namespace Ecommerce_Backend.Model
{
    public class Product:BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? ProductImgUrl { get; set; }
        public int CategoryId { get; set; }//fk
        public Category? Category { get; set; }//navigation
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}