using pandacommerce_dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_dal.Interface
{
    public interface IProduct : IRepository<Product>
    {
        public IEnumerable<Product> getProductsbyPrice(int l,int r);
    }
}
