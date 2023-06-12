using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using MenuBE.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MenuBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMenuService _menuService;
        public MenusController(IMapper mapper, IMenuService menuService)
        {
            _mapper = mapper;
            _menuService = menuService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]MenuCreateRequestDto dto)
        {
            var menu = _mapper.Map< MenuCreateRequestDto, Menu>(dto);
            menu.Id = Guid.NewGuid();
            try
            {
                await _menuService.CreateAsync(menu);
                return Ok(menu);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var menuDelete = await _menuService.DeleteAsync(id);
            if(menuDelete) {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, string name)
        {
            var menuUpdate = await _menuService.UpdateAsync(id, name);
            if (menuUpdate)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<MenuPagingResultDto> GetMenuPaging([FromQuery] MenuPagingRequestDto dto)
        {
            var menus = _menuService.GetAllAsync(dto.SkipCount, dto.MaxCount);
            var menuDtos = _mapper.Map<List<Menu>, List<MenuDto>>(menus.Result.Item2);
            var menuPagingResultDto = new MenuPagingResultDto()
            {
                TotalCount = menus.Result.Item1,
                Items = menuDtos
            };
            return menuPagingResultDto;
        }

    }
}
