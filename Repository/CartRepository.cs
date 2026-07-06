using System.Data.Common;
using Ecommerce_Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Backend.Repository
{
    public class CartRepository(AppDbContext db) : GenericRepository<Cart>(db), ICartRepository
    {
        public async Task<Cart?> GetCartByUserId(int userId)

        {      Console.WriteLine("Repository method called");
             return await db.Carts.FirstOrDefaultAsync(c=>c.UserId==userId);
        }
         public async Task<Cart?> GetCartWithItemsByUserId(int userId)

        {      Console.WriteLine("Repository method called");
             return await db.Carts.Include(c=>c.CartItems).ThenInclude(c=>c.Product).FirstOrDefaultAsync(c=>c.UserId==userId);
        }
    }
}