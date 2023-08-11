using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pandacommerce_bal.Services;
using pandacommerce_dal.Model;

namespace pandacommerceapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly ProductService pService;
        private IEnumerable<Product>? result;

        public ProductApiController(ProductService pService)
        {
            this.pService = pService;
        }
        [HttpPost("CreateNewProduct")]
        public async Task<Object> CreateNewProduct([FromBody] Product p)
        {
            try
            {
                await pService.AddNewProduct(p);
                return p;

            }
            catch (Exception ex)
            {
                return ex;
            }
        }
        [HttpGet("GetProductsbyPrice")]
        public IEnumerable<Product> GetProductsbyPrice(int l,int r)
        {
            try
            {
              return  pService.GetAllProductsBetweenPriceRange(l,r);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("ProductNameSearchByName")]
        public  IEnumerable<Product> ProductNameSearchByName(string p_name)
        {
            ;
            try
            {
                 result =  pService.GetByName(p_name);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
