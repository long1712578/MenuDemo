using System.ComponentModel.DataAnnotations;

namespace MenuBE.Dtos
{
    public class MenuCreateRequestDto
    {
        [StringLength(100)]
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}
