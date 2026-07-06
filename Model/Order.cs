using Ecommerce_Backend.Model;

namespace Ecommerce_Backend
{
    public class Order
    {
        public int Id{get;set;}
        public int? UserId{get;set;}
        public User? User{get;set;}
        public decimal TotalAmount{get;set;}
        public OrderStatus Status{get;set;}=OrderStatus.PENDING;
         public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.NOT_SHIPPED; 
        public ICollection<OrderItem>? OrderItems{get;set;}=[];
    }
    public enum OrderStatus
    {
                PENDING,FAILED,SUCCESS
    }
    public enum ShippingStatus
    {
        NOT_SHIPPED,OUT_FOR_DELIVERY,RETURNED,SHIPPED,DELIVERED
    }
}