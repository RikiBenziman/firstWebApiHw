using AutoMapper;
using DTO;
using Entities;

namespace webApiShopSite
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Product, ProductDto>();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<User, UserIdDto>();
        }

    }
}
