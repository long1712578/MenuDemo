using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if(menu.ParentId is not null)
            {
                var parentMenu = await _repository.FindAsync(menu.ParentId ?? Guid.Empty);
                if(parentMenu == null) { throw new ArgumentException("ParentId not exist!!"); };
            }
            await _repository.InsertAsync(menu);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<bool> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Menu>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Guid Id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
