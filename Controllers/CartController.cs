using System.Security.Claims;
using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Backend.Controllers
{
    [ApiController]
    [Route("api/carts")]
    public class CartController(ICartService service) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        [Route("items")]
        public async Task<IActionResult> AddTocart(CartReqDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            System.Console.WriteLine("userId fetched from token=" + userId);
            System.Console.WriteLine("addtocart service called");
            await service.AddToCart(dto, userId);
            System.Console.WriteLine("service done successfully");
            return Ok(new { msg = "product added to cart successfully" });
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCart()
        {     System.Console.WriteLine("controller called");
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            System.Console.WriteLine("service called");
            var data = await service.GetCart(userId);
            return Ok(new { msg = "fetched cart successfully", data = data });
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateCart(CartUpdateReqDto dto)
        {    
             var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
             await service.UpdateCart(dto,userId);
             return Ok(new{msg="cart update successfully"});
            
        }
         [HttpPut("{prdid}")]
        [Authorize]
        public async Task<IActionResult> RemoveCartItem(int prdId)
        {
             var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
             await service.RemoveCartItem(userId,prdId);
             return Ok(new{msg="item removed from cart successfully"});
        }
    }

}