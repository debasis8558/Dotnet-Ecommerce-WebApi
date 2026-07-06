namespace Ecommerce_Backend.Dto
{
    public class CartReqDto
    {
        public int ProductId{get;set;}
        public int Quantity{get;set;}
    }
    public class CartItemDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }

    public decimal SubTotal { get; set; }
}
    public class CartResDto
{
    public int CartId { get; set; }
    public List<CartItemDto> Items { get; set; } = [];
    public decimal Total { get; set; }
}
    public class CartUpdateReqDto
    {
        public int ProductId{get;set;}
        public int Quantity{get;set;}
    }
}
