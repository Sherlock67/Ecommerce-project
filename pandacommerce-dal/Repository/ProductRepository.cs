using Microsoft.EntityFrameworkCore;
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
            var obj = await db.Products.AddAsync(entity);
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
                return db.Products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetById(int Id)
        {
           
             return db.Products.Where(x => x.ProductId == Id).SingleOrDefault();
        }

        public IEnumerable<Product>? getProductsbyPrice(int l, int r)
        {
            Product product = new Product();
            if (product.Price >= l && product.Price <= r)
            {
                return db.Products.Where(x => x.Price >=l && x.Price <= r);
            }
            return null;
        }

        public IEnumerable<Product> Search(string p_name)
        {
            IQueryable<Product> query = db.Products;
            if (!string.IsNullOrEmpty(p_name))
            {
                query = query.Where(e=>e.ProductName.Contains(p_name));
            }
            return  query.ToList();
        }

        public void Update(Product entity)
        {
            db.Products.Update(entity);
            db.SaveChanges();
            
        }

       
    }
}
