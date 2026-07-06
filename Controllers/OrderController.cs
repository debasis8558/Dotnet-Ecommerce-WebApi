using System.Security.Claims;
using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Backend.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController(IOrderService service) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        [Route("checkout")]
        public async Task<IActionResult> PlaceOrder()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            System.Console.WriteLine("order service called");
            var res = await service.PlaceOrder(userId);
            System.Console.WriteLine("Order checkout completeed");
            return Ok(new { msg = "Order checkout completeed", data = res });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMyOrders()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var res = await service.GetMyOrders(userId);

            return Ok(new { msg = "Order fetched successfully", data = res });
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetOrderById(int id)
        {


            var res = await service.GetOrderById(id);

            return Ok(new { msg = "Order checkout completeed", data = res });

        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateShippingStatus(ShippingReqDto dto)
        {
            await service.UpdateShippingStatus(dto);
            return Ok(new{msg="implemented the request"});
        }
    }
}