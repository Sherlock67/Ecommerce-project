using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pandacommerce_bal.Services;

namespace pandacommerceapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<CustomerApiController> _logger;

        public CustomerApiController(CustomerService customerService, ILogger<CustomerApiController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }


    }
}
