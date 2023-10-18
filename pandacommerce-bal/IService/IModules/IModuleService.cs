using pandacommerce_dal.Model;

namespace pandacommerce_bal.IService.IModules
{
    public interface IModuleService
    {
        public Task<Module> AddNewModule(Module entity);
        public IEnumerable<Module> GetAllModule();
    }
}
