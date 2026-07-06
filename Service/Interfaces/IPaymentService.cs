using Ecommerce_Backend.Dto;


namespace Ecommerce_Backend.Service
{
    public interface IPaymentService
    {
        Task<PaymentResDto> Payment(PaymentReqDto dto);
    }
}