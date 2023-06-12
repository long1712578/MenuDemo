using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace MenuBE.Dtos
{
    public class MenuDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public List<Menu>? Menus { get; set; }
    }
}
