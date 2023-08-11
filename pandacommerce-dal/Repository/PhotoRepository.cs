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
            throw new NotImplementedException();
        }

        public Task<Photo> GetPhoto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
