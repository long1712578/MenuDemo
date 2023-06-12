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

        public async Task<Menu> GetAsync(Guid id)
        {
            var entity = await _context.Menus.FindAsync(id);
            //var subs = _context.Menus.Where(x => x.ParentId == id);
            //var listMenu = new List<Menu>();
            //foreach (var sub in subs)
            //{
            //    listMenu.Add(await GetSubAsync(sub));
            //}
            //entity.Menus.AddRange(listMenu);
            return entity;
        }

        //async Task<Menu> GetSubAsync(Menu entity)
        //{
        //    var subs =await  _context.Menus.Where(x => x.ParentId == entity.Id).ToListAsync();
        //    if (subs.Count > 0)
        //    {
        //        var listMenu = new List<Menu>();
        //        foreach (var sub in subs)
        //        {
        //            listMenu.Add(await GetSubAsync(sub));
        //        }
        //        entity.Menus.AddRange(listMenu);
        //    }
        //    return entity;
        //}

        public  async Task InsertAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
        }
    }
}
