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
    public class ProductRepository : IProduct
    {
        public readonly ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Product> Create(Product entity)
        {
            var obj = await db.products.AddAsync(entity);
            db.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Product entity)
        {
            db.Remove(entity);
            db.SaveChanges(); 
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                return db.products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Product GetById(int Id)
        {
            return db.products.Where(x => x.product_Id == Id).SingleOrDefault();
        }

        public IEnumerable<Product>? getProductsbyPrice(int l, int r)
        {
            Product product = new Product();
            if (product.price >= l && product.price <= r)
            {
                return db.products.Where(x => x.price >=l && x.price <= r);
            }
            return null;
        }

        public void Update(Product entity)
        {
            db.products.Update(entity);
            db.SaveChanges();
            
        }
    }
}
