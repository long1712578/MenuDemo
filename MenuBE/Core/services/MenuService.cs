﻿using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MenuService(IMenuRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task CreateAsync(Menu menu)
        {
            if(menu.ParentId.HasValue)
            {
                if(!await _repository.AnyAsync(menu.ParentId.Value)) { 
                    throw new ArgumentException("ParentId not exist!!"); 
                };
            }
            await _repository.InsertAsync(menu);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            // Delete menu
            var menu = await _repository.FindAsync(Id);
            if (menu == null)
            {
                return false;
            };
            _repository.Delete(menu);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Tuple<int, List<Menu>>> GetAllAsync(int skipCount, int maxCount)
        {
            return await _repository.GetAllAsync(skipCount, maxCount);
        }

        public async Task<bool> UpdateAsync(Guid Id, string name)
        {
            var menu = await _repository.FindAsync(Id);
            if (menu == null)
            {
                return false;
            };
            menu.Name = name;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
