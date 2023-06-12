using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Menu
    {
        public Guid Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<Menu>? Menus { get; set; }
        public bool IsDelete { get; set; }
    }
}
