using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Backend
{   [ApiController]
   [Route("api/categories")]
    public class CategoryController(ICategoryService service) : ControllerBase
    {
        [HttpPost]
         [Authorize(Roles = "Admin")]
         public async Task<IActionResult> CreateCategory(CategoryDto dto)
        {    
            
            await service.AddCategory(dto);
            return Ok(new{msg="product created successfully"});
        }
        [HttpGet]
        public async Task<IActionResult> FetchAllCAtegory()
        {
            var data=await service.GetAllCategory();
            return Ok(new{msg="implemented request successfully",data=data});
        }
       [HttpDelete]
       [Route("{id}")]
          [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveCategoryById(int id)
        {
            await service.RemoveCategory(id);
            return Ok(new{msg="successfully deleted the resource"});
        }
    }
}