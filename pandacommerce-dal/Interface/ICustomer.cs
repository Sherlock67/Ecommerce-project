using pandacommerce_dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_dal.Interface
{
    public interface ICustomer : IRepository<Customer>
    {
        public Order MakeOrder(Order order);
        
    }
}
