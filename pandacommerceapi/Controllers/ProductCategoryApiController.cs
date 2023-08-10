using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pandacommerce_bal.Services;
using pandacommerce_dal.Model;

namespace pandacommerceapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductCategoryApiController : ControllerBase
    {
        private readonly ProductCategoryService productCategoryService;
        public ProductCategoryApiController(ProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }
        [HttpPost("CreateNewProductCategory")]
        public async Task<Object> CreateNewProductCategory([FromBody] ProductCategory pCategory)
        {
            try
            {
                await productCategoryService.NewProductCategory(pCategory);
                return pCategory;

            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetAllProductCategory")]
        public List<ProductCategory> GetAllProductCategory()
        {
            var data = productCategoryService.GetAllProductCategory();
            return data.ToList();
        }

    }
}
