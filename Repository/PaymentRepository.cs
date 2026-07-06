using Ecommerce_Backend.Data;
using Ecommerce_Backend.Model;



namespace Ecommerce_Backend.Repository
{
    public class PaymentRepository(AppDbContext db) : GenericRepository<Payment>(db), IPaymentRepository
    {
       
    }
}