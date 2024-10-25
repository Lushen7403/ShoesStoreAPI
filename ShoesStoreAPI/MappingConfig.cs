using AutoMapper;
using ShoesStoreAPI.Models;
using ShoesStoreAPI.Models.DTO;

namespace ShoesStoreAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Shoe, ShoeDTO>().ReverseMap();
            CreateMap<Shoe, ShoeCreateDTO>().ReverseMap();
            CreateMap<Shoe, ShoeUpdateDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderCreateDTO>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailCreateDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();

            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Brand, BrandCreateDTO>().ReverseMap();
            CreateMap<Brand, BrandUpdateDTO>().ReverseMap();
        }
    }
}
