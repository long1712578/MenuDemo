using System.ComponentModel.DataAnnotations;

namespace MenuBE.Dtos
{
    public class MenuPagingRequestDto
    {
        [Required]
        public int SkipCount { get; set; }
        [Required]
        public int MaxCount { get; set; }
    }
}
