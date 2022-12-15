﻿using Microsoft.AspNetCore.Http;
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
    }
}
