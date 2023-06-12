using AutoMapper;
using Core.Entities;
using MenuBE.Dtos;

namespace MenuBE.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Menu, MenuDto>()
                .ForMember(dest =>dest.MenuDtos, o => o.MapFrom(x => x.Menus));
            CreateMap<MenuCreateRequestDto, Menu>();
        }
    }
}
