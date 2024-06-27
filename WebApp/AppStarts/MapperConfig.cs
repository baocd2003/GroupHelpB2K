using AutoMapper;
using BusinessObjects;
using BusinessObjects.DTO;

namespace WebApp.AppStarts
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<PublisherDTO, Publisher>().ReverseMap();
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus.ToString()));
        }
    }
}
