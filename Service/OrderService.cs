using System.Data.Common;
using AutoMapper;
using Ecommerce_Backend.Data;
using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Exceptions;
using Ecommerce_Backend.Model;
using Ecommerce_Backend.Repository;

namespace Ecommerce_Backend.Service
{
    public class Orderservice(ICartRepository cartRepo, ICartItemRepository cartItemRepo, IOrderRepository orderRepo, IProductRepository prdRepo, IMapper mapper, AppDbContext db) : IOrderService
    {
        public async Task<OrderResDto> PlaceOrder(int userId)
        {
            using var transaction = await db.Database.BeginTransactionAsync();
            try
            {
                System.Console.WriteLine("order transaction started");
                var cart = await cartRepo.GetCartWithItemsByUserId(userId) ?? throw new NotFoundException("cart is empty! order can not be placed");
                System.Console.WriteLine("cart is fetched" + $"{cart.CartItems}");
                var order = new Order
                {
                    UserId = cart.UserId,
                    Status = OrderStatus.PENDING,
                    ShippingStatus = ShippingStatus.NOT_SHIPPED

                };
                decimal totalAmt = 0;

                foreach (var c in cart.CartItems)
                {
                    var product = c.Product!;
                    if (product.Stock < c.Quantity)
                    {
                        throw new BadRequestException("invalid qunatity");
                    }
                    var orderItem = new OrderItem
                    {
                        ProductId = product.Id,
                        Quantity = c.Quantity,
                        Product = product,
                        PurchasePrice = product.Price
                    };
                    System.Console.WriteLine("new orderItem=" + orderItem);
                    order.OrderItems.Add(orderItem);
                    totalAmt += product.Price * c.Quantity;
                    product.Stock -= c.Quantity;
                    prdRepo.Update(product);

                }
                order.TotalAmount = totalAmt;
                await prdRepo.SaveChange();
                await orderRepo.Add(order);
                await orderRepo.SaveChange();
                foreach (var c in cart.CartItems)
                {
                    cartItemRepo.Delete(c);
                }
                await cartItemRepo.SaveChange();
                await transaction.CommitAsync();
                System.Console.WriteLine("transaction completed");
                return mapper.Map<OrderResDto>(order);

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("transaction finished");
                await transaction.RollbackAsync();
                throw ex;
            }

        }
        public async Task<List<OrderResDto>> GetMyOrders(int userId)
        {
            var order = await orderRepo.GetMyOrders(userId);
            System.Console.WriteLine($"Order Count: {order.Count}");
            return mapper.Map<List<OrderResDto>>(order);

        }
        public async Task<OrderResDto> GetOrderById(int id)
        {
            var order = await orderRepo.GetOrderById(id) ?? throw new NotFoundException("Order not found"); ;


            return mapper.Map<OrderResDto>(order);

        }
        public async Task UpdateShippingStatus(ShippingReqDto dto)
        {
            Console.WriteLine($"Received OrderId = {dto.OrderId}");
            var order = await orderRepo.GetOrderById(dto.OrderId) ?? throw new NotFoundException("order not found");
            if (order.Status != OrderStatus.SUCCESS)
            {
                throw new BadRequestException("Cannot update shipping status until payment is successful");
            }
            if (!Enum.TryParse<ShippingStatus>(dto.ShippingStatus, true, out var status))
            {
                throw new BadRequestException("invalid request");
            }
            order.ShippingStatus = status;
            mapper.Map(dto, order);
            orderRepo.Update(order);
            await orderRepo.SaveChange();
        }

    }
}