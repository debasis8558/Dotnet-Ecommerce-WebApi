using AutoMapper;
using Ecommerce_Backend.Model;
using Ecommerce_Backend.Dto;



namespace Ecommerce_Backend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ✅ User Mapping
            CreateMap<SignUpDto, User>();

            // ✅ Product Mapping
            CreateMap<ProductReqDto, Product>();
            CreateMap<Product, ProductReqDto>();
            CreateMap<Product, ProductResDto>();
            // ✅ Category Mapping
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryResponseDto>();
            CreateMap<Order, OrderResDto>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.ShippingStatus, opt => opt.MapFrom(src => src.ShippingStatus.ToString()));
            
            CreateMap<OrderItem, OrderItemResDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : ""))
                .ForMember(dest => dest.PriceAtPurchase, opt => opt.MapFrom(src => src.PurchasePrice))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.PurchasePrice * src.Quantity));

            CreateMap<Payment, PaymentResDto>()
    .ForMember(
        dest => dest.Status,
        opt => opt.MapFrom(src => src.Status.ToString())
    );

        }
    }
}