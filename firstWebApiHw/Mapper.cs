using AutoMapper;
using DTO;
using Entities;

namespace webApiShopSite
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap()
                .ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.CategoryName));
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<User, UserIdNameDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }

    }
}
