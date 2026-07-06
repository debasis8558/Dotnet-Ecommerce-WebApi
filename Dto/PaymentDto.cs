using Ecommerce_Backend.Model;



namespace Ecommerce_Backend.Dto
{
    public class PaymentResDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public decimal Amount { get; set; }

        public string TransactionId { get; set; } = string.Empty;
        public string? Status { get; set; }
  
        public DateTime? PaidAt { get; set; }
    }
    public class PaymentReqDto
    {
        public int OrderId { get; set; }
        public bool IsSuccess { get; set; }
    }
}
