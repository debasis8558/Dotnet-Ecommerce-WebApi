namespace Ecommerce_Backend.Model
{
    public class User:BaseEntity
    {
        public int Id { get; set; }
        public string? Name {  get; set; }
        public string? Email { get; set; }
        public string? Role{get;set;}="Customer";
        public string? Password {  get; set; }
        public ICollection<Order>? Order{get;set;}=[];
    }
}
