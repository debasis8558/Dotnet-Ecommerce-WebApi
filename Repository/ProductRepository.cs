using System.Data.Common;
using System.Net.Sockets;
using Ecommerce_Backend.Data;
using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Exceptions;
using Ecommerce_Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Backend.Repository
{
    public class ProductRepository(AppDbContext db,IWebHostEnvironment env) : GenericRepository<Product>(db), IProductRepository
    {
        
        public async Task<List<ProductResDto>> SearchProduct(ProductQueryDto dto)
        {   System.Console.WriteLine("build the query");
            var query = db.Products.AsQueryable();
            if (!String.IsNullOrEmpty(dto.KeyWord))
            {
                query = query.Where(p => p.Name.Contains(dto.KeyWord));
            }
            if (dto.CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == dto.CategoryId.Value);
            }
            if (dto.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= dto.MaxPrice.Value);
            }
            if (dto.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= dto.MinPrice.Value);
            }
            query = query.Skip((dto.Page - 1) * dto.PageSize).Take(dto.PageSize);
            var res = await query.Select(p => new ProductResDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
                
            }).ToListAsync();
            System.Console.WriteLine("final query res is="+res);
            return res;
        }
        public async Task<string> UploadProductImage(IFormFile file)
        {
            if(file == null || file.Length==0)
            {
                throw new BadRequestException("no file found");
            }
            string path=Path.Combine(env.ContentRootPath,"uploads","product");
            Directory.CreateDirectory(path);
            string filePath=Path.Combine(path,file.FileName);
            using(Stream fileStream=new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            string ImgUrl=$"/uploads/product/{file.FileName}";
            return ImgUrl;
        }
    }
}