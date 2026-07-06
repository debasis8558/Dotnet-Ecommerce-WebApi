using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Model;

namespace Ecommerce_Backend.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<ProductResDto>> SearchProduct(ProductQueryDto dto);
        Task<string>  UploadProductImage(IFormFile file);
    }
}