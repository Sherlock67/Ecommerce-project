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
    }
}
