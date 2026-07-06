using Ecommerce_Backend.Dto;

namespace Ecommerce_Backend.Repository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<Order>>GetMyOrders(int userId);
       Task<Order?> GetOrderById(int id);
       //Task<ShippingResDto> UpdateShippingStatus(int orderId,string status);
    }
}