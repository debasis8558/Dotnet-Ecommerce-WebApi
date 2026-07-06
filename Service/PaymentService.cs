using AutoMapper;
using Ecommerce_Backend.Data;
using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Exceptions;
using Ecommerce_Backend.Model;
using Ecommerce_Backend.Repository;

namespace Ecommerce_Backend.Service
{
    public class PaymentService(IPaymentRepository paymentRepo, IOrderRepository orderRepo, AppDbContext db, IMapper mapper) : IPaymentService
    {
        public async Task<PaymentResDto> Payment(PaymentReqDto dto)
        {
            using var transaction = await db.Database.BeginTransactionAsync();
            try
            {
                var order = await orderRepo.GetOrderById(dto.OrderId) ?? throw new NotFoundException("resourse not found");
                var payment = new Payment
                {
                    OrderId = order.Id,
                    Amount = order.TotalAmount,
                    TransactionId = Guid.NewGuid().ToString(),
                    Status = dto.IsSuccess ? PaymentStatus.SUCCESS : PaymentStatus.FAILED,
                    PaidAt = dto.IsSuccess ? DateTime.UtcNow : null
                };
                if (dto.IsSuccess)
                {
                    order.Status = OrderStatus.SUCCESS;
                    order.ShippingStatus=ShippingStatus.SHIPPED;
                    orderRepo.Update(order);


                }
                else
                {
                    order.Status = OrderStatus.FAILED;
                    order.ShippingStatus=ShippingStatus.NOT_SHIPPED;
                    orderRepo.Update(order);

                }
                await orderRepo.SaveChange();
                await paymentRepo.Add(payment);
                await paymentRepo.SaveChange();
                await transaction.CommitAsync();
                var res = mapper.Map<PaymentResDto>(payment);

                Console.WriteLine(res.Status);

                return res;

            }
            catch (System.Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }

        }
    }
}