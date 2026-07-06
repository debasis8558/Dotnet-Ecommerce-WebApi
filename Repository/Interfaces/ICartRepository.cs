using Ecommerce_Backend.Repository;

namespace Ecommerce_Backend
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
         Task<Cart?> GetCartByUserId(int UserId);
         Task<Cart?>GetCartWithItemsByUserId(int userId);
    }
}