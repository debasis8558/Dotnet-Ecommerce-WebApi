using Ecommerce_Backend.Dto;
using Microsoft.AspNetCore.Authentication;

namespace Ecommerce_Backend.Service
{
    public interface IProductService
    {
         Task AddProduct(ProductReqDto dto);
        Task<List<ProductResDto>> GetAllProduct();
        Task RemoveProduct(int id);
        Task UpdateProduct(ProductReqDto dto,int id);
        Task <ProductResDto> GetProductById(int id);
        Task<List<ProductResDto>> SearchProduct(ProductQueryDto dto);
    }
}