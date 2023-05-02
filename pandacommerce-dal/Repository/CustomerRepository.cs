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
    public class CustomerRepository : ICustomer
    {
        public readonly ApplicationDbContext db;
        public CustomerRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Customer> Create(Customer entity)
        {
            var obj = await db.Customers.AddAsync(entity);
            db.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Customer entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                return db.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer GetById(int Id)
        {
            return db.Customers.Where(x => x.CustomerId == Id).SingleOrDefault();
        }

        public Order MakeOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            db.Customers.Update(entity);
            db.SaveChanges();
        }
    }
}
