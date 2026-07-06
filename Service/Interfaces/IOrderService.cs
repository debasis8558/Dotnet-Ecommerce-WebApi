using Ecommerce_Backend.Dto;


namespace Ecommerce_Backend.Service
{
    public interface IOrderService
    {
        Task<OrderResDto> PlaceOrder(int userId);
        Task<List<OrderResDto>> GetMyOrders(int userId);
        Task<OrderResDto> GetOrderById(int id);
        Task UpdateShippingStatus(ShippingReqDto dto);
    }
}