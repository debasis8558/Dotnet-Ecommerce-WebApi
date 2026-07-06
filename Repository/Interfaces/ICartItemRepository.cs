using Ecommerce_Backend.Repository;

namespace Ecommerce_Backend
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<CartItem?> GetCartItemAsync(int CartId,int ProductId);
    }
}