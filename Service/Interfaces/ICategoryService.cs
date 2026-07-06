using Ecommerce_Backend.Dto;

namespace Ecommerce_Backend.Service
{
    public interface ICategoryService
    {
        Task AddCategory(CategoryDto dto);
        Task<List<CategoryResponseDto>> GetAllCategory();
        Task RemoveCategory(int id);
    }
}