using pandacommerce_dal.Model;

namespace pandacommerce_bal.IService.IProducts
{
    public interface IProductService 
    {
        public Task<Product> AddNewProduct(Product product);
        public IEnumerable<Product> GetAllProducts();
    }
}
