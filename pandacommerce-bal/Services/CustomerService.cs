using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_bal.Services
{
    public class CustomerService
    {
        public readonly IAuthRepository auth;
        public readonly ICustomer customer;
        public CustomerService(IAuthRepository auth, ICustomer customer)
        {
            this.auth = auth;
            this.customer = customer;
        }

        public async Task<Customer> RegisterCustomer(Customer nav)
        {
            return await customer.Create(nav);
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            try
            {
                return customer.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task DeleteNavigationCategory(int id)
        //{

        //    try
        //    {
        //        var cat = customer.GetById(id);
        //        customer.Delete(cat);

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        public async Task UpdateCustomerInformation(Customer obj)
        {
            try
            {
                customer.Update(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
