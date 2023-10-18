using pandacommerce_dal.Model;
using pandacommerce_dal.ViewModels.Logins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_dal.Interface
{
    public interface ILoginRepository : IRepository<AppUser>
    {
        public vmLogin UserLogin(string username, string password);
    }
}
