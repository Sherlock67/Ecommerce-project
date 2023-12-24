using pandacommerce_bal.IService.IModules;
using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;

namespace pandacommerce_bal.Services
{
    public class ModuleService : IModuleService
    {
        public readonly IModule module;
        public ModuleService(IModule module)
        {
            this.module = module;
        }

        public async Task<Module> AddNewModule(Module entity)
        {
            return await module.Create(entity);   
        }

        public IEnumerable<Module> GetAllModule()
        {
            throw new NotImplementedException();
        }
    }
}
