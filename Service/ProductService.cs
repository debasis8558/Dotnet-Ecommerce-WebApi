using AutoMapper;
using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Exceptions;
using Ecommerce_Backend.Model;
using Ecommerce_Backend.Repository;
using Ecommerce_Backend.Service;

namespace Ecommerce_Backend
{
    public class ProductService(IProductRepository repo, IMapper mapper) : IProductService
    {
        public async Task AddProduct(ProductReqDto dto)
        {
            var productUrl = await repo.UploadProductImage(dto.ProductImgUrl);
            var product = mapper.Map<Product>(dto);//dto->entity
            product.ProductImgUrl = productUrl;
            await repo.Add(product);
            await repo.SaveChange();
        }
        public async Task RemoveProduct(int id)
        {
            var prd = await repo.GetById(id) ?? throw new NotFoundException("resource was not found");
            repo.Delete(prd);
            await repo.SaveChange();
        }
        public async Task UpdateProduct(ProductReqDto dto, int id)
        {
            var prd = await repo.GetById(id) ?? throw new NotFoundException("resource was not found");
            mapper.Map(dto, prd);
            repo.Update(prd);
            await repo.SaveChange();

        }
        public async Task<List<ProductResDto>> GetAllProduct()
        {
            var prd = await repo.GetAll();
            return mapper.Map<List<ProductResDto>>(prd); //entity->dto
           
        }
        public async Task<ProductResDto> GetProductById(int id)
        {
            var prd = await repo.GetById(id) ?? throw new NotFoundException("resource was not found");
            return mapper.Map<ProductResDto>(prd);
        }

        public async Task<List<ProductResDto>> SearchProduct(ProductQueryDto dto)
        {
            System.Console.WriteLine("calling repo searchProduct logic");
            var res = await repo.SearchProduct(dto);
            return res;
        }

    }
}