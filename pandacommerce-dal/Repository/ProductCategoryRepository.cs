using pandacommerce_dal.Data;
using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_dal.Repository
{
    public class ProductCategoryRepository : IProductCategory
    {
        public readonly ApplicationDbContext db;
        public ProductCategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<ProductCategory> Create(ProductCategory entity)
        {
            var obj = await db.productCategories.AddAsync(entity);
            db.SaveChanges();
            return obj.Entity;
        }

        public void Delete(ProductCategory entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            try
            {
                return db.productCategories.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductCategory GetById(int Id)
        {
            return db.productCategories.Where(x => x.CategoryID == Id).SingleOrDefault();
            //throw new NotImplementedException();
        }

        public void Update(ProductCategory entity)
        {
            db.productCategories.Update(entity);
            db.SaveChanges();
        }
    }
}
