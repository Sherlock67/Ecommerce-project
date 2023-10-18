using Microsoft.AspNetCore.Mvc;
using pandacommerce_bal.Services;
using pandacommerce_dal.Model;
using System.Text.Json;

namespace pandacommerceapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NavApiController : ControllerBase
    {
        private readonly NavCategoryService navCategoryService;
        private readonly ILogger<NavApiController> _logger;
        public NavApiController(NavCategoryService navCategoryService, ILogger<NavApiController> logger)
        {
            this.navCategoryService = navCategoryService;
            _logger = logger;
        }
        [HttpPost("CreateNavigationCategory")]
        public async Task<Object> CreateNavigationCategory([FromBody] NavCategory navCategory)
        {
            try
            {
                _logger.LogInformation("Executing {Action} with parameters: {Parameters}", nameof(navCategory), JsonSerializer.Serialize(navCategory));
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
            var data = navCategoryService.GetAllNavigationCategory();
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
