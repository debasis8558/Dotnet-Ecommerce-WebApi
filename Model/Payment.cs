namespace Ecommerce_Backend.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.PENDING;
        public string? TransactionId { get; set; }   // gateway se aayega (Razorpay/Stripe transaction id)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PaidAt { get; set; }   // jab payment successful hua tab ka time
    }

    public enum PaymentStatus
    {
        PENDING, SUCCESS, FAILED
    }
}