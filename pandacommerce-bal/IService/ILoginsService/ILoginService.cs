using pandacommerce_dal.ViewModels.Logins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_bal.IService.ILoginsService
{
    public interface ILoginService
    {
        public vmLogin UserLogin(string username, string password);
    }
}
