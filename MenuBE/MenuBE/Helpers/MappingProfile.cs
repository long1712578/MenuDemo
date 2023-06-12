using AutoMapper;
using Core.Entities;
using MenuBE.Dtos;

namespace MenuBE.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Menu, MenuDto>();
            CreateMap<MenuCreateRequestDto, Menu>();
        }
    }
}
