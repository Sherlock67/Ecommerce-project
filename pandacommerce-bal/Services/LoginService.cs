using pandacommerce_bal.IService.ILoginsService;
using pandacommerce_dal.Interface;
using pandacommerce_dal.ViewModels.Logins;

namespace pandacommerce_bal.Services
{
    public class LoginService : ILoginService
    {
        public readonly ILoginRepository loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }
        public vmLogin UserLogin(string username, string password)
        {
            return loginRepository.UserLogin(username, password);

            //throw new NotImplementedException();
        }
    }
}
