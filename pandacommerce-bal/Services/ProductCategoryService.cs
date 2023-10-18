using pandacommerce_bal.IService.IProductCategory;
using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;

namespace pandacommerce_bal.Services
{
    public class ProductCategoryService : IProductCategorysService
    {
        private readonly IProductCategory productCategory;
        public ProductCategoryService(IProductCategory productCategory)
        {
            this.productCategory = productCategory;
        }
        public async Task<ProductCategory> AddNewProductCategory(ProductCategory pCategory)
        {
            return await productCategory.Create(pCategory);
        }
        public IEnumerable<ProductCategory> GetAllProductCategory()
        {
            try
            {
                return productCategory.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }



    }
}
