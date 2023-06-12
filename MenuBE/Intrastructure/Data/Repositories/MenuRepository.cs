using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intrastructure.Data.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly MenuContext _context;

        public MenuRepository(MenuContext context)
        {
            _context = context;
        }

        public void Delete(Menu menu)
        {
            var subs = _context.Menus.Where(x => x.ParentId == menu.Id).ToList();
            if (subs.Count > 0)
            {
                var listMenu = new List<Menu>();
                foreach (var sub in subs)
                {
                    Delete(sub);
                }
            }
            _context.Menus.Remove(menu);
        }

        public async Task<Menu> FindAsync(Guid id)
        {
            var entity = await _context.Menus.FindAsync(id);
            return entity;
        }

        public async Task<Tuple<int, List<Menu>>> GetAllAsync(int skipCount, int maxCount)
        {
            var queryable =  _context.Menus.Where(x=> x.ParentId == null).AsQueryable();
            var totalCount = await queryable.CountAsync();
            var menus = await queryable
                .AsNoTracking()
                .Skip(skipCount)
                .Take(maxCount)
                .ToListAsync();
            // Get menu sub
            var lstMenu = new List<Menu>();
            foreach (var menu in menus)
            {
                lstMenu.Add(GetMenuSubAsync(menu));
            }
            return new Tuple<int, List<Menu>>(totalCount, lstMenu);
        }

        public  async Task InsertAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
        }

        private Menu GetMenuSubAsync(Menu menu)
        {
            var subs = _context.Menus.Where(x => x.ParentId == menu.Id).ToList();
            var listSub = new List<Menu>();
            if(subs.Count > 0)
            {
                foreach (var sub in subs)
                {
                    listSub.Add(GetMenuSubAsync(sub));
                }
                menu.Menus.AddRange(listSub);
            }
            return menu;
        }
    }
}
