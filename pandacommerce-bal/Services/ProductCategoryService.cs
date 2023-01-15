using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_bal.Services
{
    public class ProductCategoryService
    {
        private readonly IProductCategory productCategory;
        public ProductCategoryService(IProductCategory productCategory)
        {
            this.productCategory = productCategory;
        }
        public async Task<ProductCategory> NewProductCategory(ProductCategory pCategory)
        {
            return await productCategory.Create(pCategory);
        }

    }
}
