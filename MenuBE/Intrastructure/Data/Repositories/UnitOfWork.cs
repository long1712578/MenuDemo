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

        public UnitOfWork(MenuContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
             await _context.SaveChangesAsync();
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
