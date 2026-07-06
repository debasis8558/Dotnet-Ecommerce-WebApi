using System.Text.Json.Serialization;

namespace Ecommerce_Backend.Dto
{
    public class ProductReqDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public IFormFile? ProductImgUrl { get; set; }


        public int CategoryId { get; set; }
    }
    public class ProductResDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ProductImgUrl { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Stock { get; set; }

    }
    public class ProductQueryDto
    {
        public string? KeyWord { get; set; }
        public int? CategoryId { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}