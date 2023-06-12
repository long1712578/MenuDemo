using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intrastructure.Data.Repositories
{
    public class MenuRepository: IMenuRepository
    {
        private readonly MenuContext _context;

        public MenuRepository(MenuContext context)
        {
            _context = context;
        }

        public async Task<Menu> FindAsync(Guid id)
        {
            var entity = await _context.Menus.FindAsync(id);
            return entity;
        }

        public  async Task InsertAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
        }
    }
}
