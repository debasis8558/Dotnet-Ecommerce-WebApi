using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Exceptions;
using Ecommerce_Backend.Repository;
using Ecommerce_Backend.Repository.Interfaces;

namespace Ecommerce_Backend.Service
{
    public class CategoryService(ICategoryRepository repo, IMapper mapper) : ICategoryService
    {
        public async Task AddCategory(CategoryDto dto)
        {
            var category = mapper.Map<Category>(dto);
            await repo.Add(category);
            await repo.SaveChange();
        }
        public async Task<List<CategoryResponseDto>> GetAllCategory()
        {
            return mapper.Map<List<CategoryResponseDto>>(await repo.GetAll());
        }
        public async Task RemoveCategory(int id)
        {
            var category = await repo.GetById(id) ?? throw new NotFoundException("category not found");
            repo.Delete(category);
            await repo.SaveChange();
        }
    }
}