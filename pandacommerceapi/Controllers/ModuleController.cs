using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pandacommerce_bal.IService.IModules;
using pandacommerce_bal.IService.INavigations;
using pandacommerce_bal.Services;
using pandacommerce_dal.Model;
using System.Text.Json;

namespace pandacommerceapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService moduleService;
        private IConfiguration _config;
        private readonly ILogger<ModuleController> _logger;
        public ModuleController(IModuleService moduleService, ILogger<ModuleController> logger, IConfiguration config)
        {
            this.moduleService = moduleService;
            _logger = logger;
            _config = config;
        }

        [HttpPost("CreateNewModule")]

        public async Task<Object> CreateNewModule([FromBody] Module module)
        {
            try
            {
                _logger.LogInformation("Executing {Action} with parameters: {Parameters}", nameof(module), JsonSerializer.Serialize(module));
                await moduleService.AddNewModule(module);
                return module;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
