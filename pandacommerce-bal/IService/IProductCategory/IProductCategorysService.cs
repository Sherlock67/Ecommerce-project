using pandacommerce_dal.Model;

namespace pandacommerce_bal.IService.IProductCategory
{
    public interface IProductCategorysService
    {
        public Task<ProductCategory> AddNewProductCategory(ProductCategory productCategory);
        public IEnumerable<ProductCategory> GetAllProductCategory();
    }
}
