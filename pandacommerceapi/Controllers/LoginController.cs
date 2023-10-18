using Microsoft.AspNetCore.Mvc;
using pandacommerce_bal.IService.ILoginsService;
using pandacommerce_bal.Services;
using pandacommerce_dal.Model;
using pandacommerce_dal.ViewModels.Logins;
using System.Text.Json;

namespace pandacommerceapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        private readonly ILogger<LoginController> _logger;
        public LoginController(ILoginService loginService, ILogger<LoginController> logger)
        {
            this.loginService = loginService;
            _logger = logger;
        }
        [HttpPost("CreateLogin")]
        public async Task<Object> CreateLogin([FromBody] vmLogin vmLogin)
        {
            try
            {
                _logger.LogInformation("Executing {Action} with parameters: {Parameters}", nameof(vmLogin), JsonSerializer.Serialize(vmLogin));
                return  loginService.UserLogin(vmLogin.UserName,vmLogin.Password);
               //return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
       
      
   



    }
}
