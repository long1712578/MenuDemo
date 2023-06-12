using Core.Interfaces;
using Intrastructure.Data;
using Intrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MenuContext _context;
        private bool _disposed = false;

        public IMenuRepository MenuRepository { get; }
        public UnitOfWork(MenuContext context)
        {
            _context = context;
            MenuRepository = new MenuRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }
        }
    }
}
