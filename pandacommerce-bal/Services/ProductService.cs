using pandacommerce_bal.IService.IProducts;
using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;

namespace pandacommerce_bal.Services
{
    public class ProductService : IProductService
    {
        public readonly IProduct product;
        public ProductService(IProduct product)
        {
            this.product = product;
        }
        public async Task<Product> AddNewProduct(Product p)
        {
            return await product.Create(p);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProductsBetweenPriceRange(int l,int r)
        {
            try
            {
                return product.getProductsbyPrice(l, r);
            }
            catch(Exception ex ) 
            {
                throw;

            }
        }
        public  IEnumerable<Product> GetByName(string p_name)
        {
            try
            {
                return product.Search(p_name);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
