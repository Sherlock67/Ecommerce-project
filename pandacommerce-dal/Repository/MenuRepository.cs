using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_dal.Repository
{
    public class MenuRepository : IMenu
    {
        public Task<Menu> Create(Menu entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Menu entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> GetAll()
        {
            throw new NotImplementedException();
        }

        public Menu GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Menu entity)
        {
            throw new NotImplementedException();
        }
    }
}
