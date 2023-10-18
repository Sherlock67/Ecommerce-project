using pandacommerce_dal.Data;
using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;

namespace pandacommerce_dal.Repository
{
    public class NavCategoryRepository : INavCategory
    {
        public readonly ApplicationDbContext db;
        public NavCategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<NavCategory> Create(NavCategory entity)
        {
            var obj = await db.navCategories.AddAsync(entity);
            db.SaveChanges();
            return obj.Entity;
           // throw new NotImplementedException();
        }

        public void Delete(NavCategory entity)
        {
            db.Remove(entity);
            db.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<NavCategory> GetAll()
        {
            try
            {
                return db.navCategories.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //throw new NotImplementedException();
        }

        public NavCategory GetById(int Id)
        {
            return db.navCategories.Where(x => x.NavCategoryId == Id).SingleOrDefault();
        }

        public void Update(NavCategory entity)
        {
            db.navCategories.Update(entity);
            db.SaveChanges();
        }
    }
}
