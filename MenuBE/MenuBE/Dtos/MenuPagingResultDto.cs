namespace MenuBE.Dtos
{
    public class MenuPagingResultDto
    {
        public int TotalCount { get; set; }
        public List<MenuDto> Items { get; set; }
    }
}
