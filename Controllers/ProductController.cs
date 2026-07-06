using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Backend.Controllers
{
    [ApiController]
    [Route("api/products")]

    public class ProductController(IProductService service) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct([FromForm] ProductReqDto dto)
        {
            await service.AddProduct(dto);
            return Ok(new { msg = "product added successfully" });
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await service.RemoveProduct(id);
            return Ok(new { msg = "product removed successfully" });
        }
        [HttpPatch]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(ProductReqDto dto, int id)
        {
            await service.UpdateProduct(dto, id);
            return Ok(new { msg = "product data updated successfully" });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var prd = await service.GetAllProduct();
            return Ok(new { msg = "product fetched successfully", data = prd });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var res = await service.GetProductById(id);
            return Ok(new { msg = "product fetched successfully", data = res });
        }
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchProduct([FromQuery] ProductQueryDto dto)
        {
            Console.WriteLine(
    $"Keyword={dto.KeyWord}, CategoryId={dto.CategoryId}, MinPrice={dto.MinPrice}, MaxPrice={dto.MaxPrice}, Page={dto.Page}, PageSize={dto.PageSize}"
);
            var res = await service.SearchProduct(dto);
            System.Console.WriteLine("query search finished");
            return Ok(new { msg = "product fetched successfully", data = res });
        }

    }
}