namespace Ecommerce_Backend.Dto

    
{    public class OrderResDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string ShippingStatus{get;set;}=string.Empty;
     
        public List<OrderItemResDto> Items { get; set; } = [];
    }

    public class OrderItemResDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class ShippingReqDto
    {
      public string? ShippingStatus { get; set; }
        public int OrderId{get;set;}
    }
}
