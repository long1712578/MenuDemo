using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMenuService
    {
        Task<bool> Create(Menu menu);
        Task<bool> Update(Guid Id, string name);
        Task<bool> Delete(Guid Id);
        Task<List<Menu>> GetAll();

    }
}
