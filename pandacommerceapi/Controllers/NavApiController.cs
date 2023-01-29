using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pandacommerce_bal.Services;
using pandacommerce_dal.Model;

namespace pandacommerceapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NavApiController : ControllerBase
    {
        private readonly NavCategoryService navCategoryService;
        public NavApiController(NavCategoryService navCategoryService)
        {
            this.navCategoryService = navCategoryService;
        }
        [HttpPost("CreateNavigationCategory")]
        public async Task<Object> CreateNavigationCategory([FromBody] NavCategory navCategory)
        {
            try
            {
                await navCategoryService.AddNewCategory(navCategory);
                return navCategory;

            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpGet("GetAllNavigationCategory")]
        public List<NavCategory> GetAllNavigationCategory()
        {
            var data = navCategoryService.GetAllNavCategory();
            return data.ToList();
        }
        [HttpDelete("DeleteNavCategory")]
        public bool DeleteNavCategory(int id)
        {
            try
            {
                navCategoryService.DeleteNavigationCategory(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPut("UpdateNavCategory")]
        public bool UpdateNavCategory(NavCategory navCategory)
        {
            try
            {
                navCategoryService.UpdateNavigationCategory(navCategory);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}
