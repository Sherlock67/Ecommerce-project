using pandacommerce_dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_dal.Interface
{
    public interface IAuthRepository
    {
        Task<Customer> RegisterUser(Customer customer, string password);
        Task<Customer> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
