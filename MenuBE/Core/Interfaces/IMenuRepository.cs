using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMenuRepository
    {
        Task InsertAsync(Menu menu);
        Task<Menu> FindAsync(Guid id);
        void Delete(Menu menu);
        Task<Tuple<int, List<Menu>>> GetAllAsync(int skipCount, int maxCount);
    }
}
