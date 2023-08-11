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
    public class PhotoRepository : IPhoto
    {
        private readonly ApplicationDbContext db;
        public PhotoRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add<T>(T entity) where T : class
        {
            db.Add<T>(entity);
            //throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            db.Remove(entity);
            //throw new NotImplementedException();
        }

        public async Task<Photo> GetPhoto(int id)
        {
            //throw new NotImplementedException();
            return await db.Photos.FirstAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts(int id)
        {
            return await db.Products.Include(p => p.Photos).ToListAsync();
        }
    }
}
