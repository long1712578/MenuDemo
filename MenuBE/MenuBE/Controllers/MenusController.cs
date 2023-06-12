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
        public async Task<IActionResult> Create(MenuCreateRequestDto dto)
        {
            var menu = _mapper.Map< MenuCreateRequestDto, Menu>(dto);
            menu.Id = Guid.NewGuid();
            try
            {
                await _menuService.CreateAsync(menu);
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
