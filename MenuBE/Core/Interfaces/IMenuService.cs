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
        Task CreateAsync(Menu menu);
        Task<bool> UpdateAsync(Guid Id, string name);
        Task<bool> DeleteAsync(Guid Id);
        Task<Tuple<int, List<Menu>>> GetAllAsync(int skipCount, int maxCount);

    }
}
