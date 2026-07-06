using Ecommerce_Backend.Data;
using Ecommerce_Backend.Dto;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Backend.Repository
{
    public class OrderRepository(AppDbContext db) : GenericRepository<Order>(db), IOrderRepository
    {
        public async Task<List<Order>> GetMyOrders(int userId)
        {

            return await db.Orders
                    .Include(o => o.OrderItems!)
                    .ThenInclude(oi=>oi.Product)
                    .Where(o => o.UserId == userId)
                    .ToListAsync();

        }
         public async Task<Order?> GetOrderById(int id)
        {

            return await db.Orders
                    .Include(o => o.OrderItems!)
                    .ThenInclude(oi=>oi.Product)
                    .FirstOrDefaultAsync(o => o.Id == id);
            

        }

    }
}