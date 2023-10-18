using pandacommerce_dal.Data;
using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;

namespace pandacommerce_dal.Repository
{
    public class ModuleRepository : IModule
    {

        private readonly ApplicationDbContext db;
        public ModuleRepository(ApplicationDbContext db)
        {
            this.db = db;
            
        }
        public async Task<Module> Create(Module entity)
        {
            var obj = await db.Modules.AddAsync(entity);
            db.SaveChanges();
            return obj.Entity;
           
        }

        public void Delete(Module entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Module> GetAll()
        {
            throw new NotImplementedException();
        }

        public Module GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Module entity)
        {
            throw new NotImplementedException();
        }
    }
}
