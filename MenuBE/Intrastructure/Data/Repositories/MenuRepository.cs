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
        private readonly MenuContext _menueContext;

        public MenuRepository(MenuContext storeContext)
        {
            _menueContext = storeContext;
        }
    }
}
