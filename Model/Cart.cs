using Ecommerce_Backend.Model;

namespace Ecommerce_Backend
{
    public class Cart:BaseEntity
    {
        public int Id{get;set;}
        public int UserId{get;set;}
        public User? User{get;set;}
        public List<CartItem> CartItems{get;set;}=[];

    }
}