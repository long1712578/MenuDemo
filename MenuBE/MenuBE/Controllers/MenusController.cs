using AutoMapper;
using Core.Entities;
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
        public MenusController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(MenuCreateRequestDto dto)
        {
            var menu = _mapper.Map< MenuCreateRequestDto, Menu>(dto);
            menu.Id = Guid.NewGuid();

            return Ok();
        }
    }
}
