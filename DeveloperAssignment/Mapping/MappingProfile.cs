using AutoMapper;
using DeveloperAssignment.DAL.Models;
using DeveloperAssignment.Models;

namespace DeveloperAssignment.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemDTO, Item>()
                .ForMember(src => src.Category,  map => map.MapFrom(dest => dest.Category.Name));

            CreateMap<Item, ItemDTO>()
                .ForMember(src => src.Category, opt => opt.Ignore());

            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
