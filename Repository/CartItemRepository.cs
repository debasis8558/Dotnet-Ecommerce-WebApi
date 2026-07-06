using System.Data.Common;
using Ecommerce_Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Backend.Repository
{
    public class CartItemRepository(AppDbContext db) : GenericRepository<CartItem>(db), ICartItemRepository
    {
        public async Task<CartItem?> GetCartItemAsync(int CartId,int ProductId)
        {
            return await db.CartItems.FirstOrDefaultAsync(c=>c.CartId==CartId && c.ProductId==ProductId);
        }
    }
}