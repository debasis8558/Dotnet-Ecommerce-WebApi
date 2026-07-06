using Ecommerce_Backend.Dto;

namespace Ecommerce_Backend.Service
{
    public interface ICartService
    {
        Task AddToCart(CartReqDto dto,int userId);
        Task<CartResDto>GetCart(int userId);
        Task UpdateCart(CartUpdateReqDto dto,int userId);
        Task RemoveCartItem(int userId,int prdId);
    }
}