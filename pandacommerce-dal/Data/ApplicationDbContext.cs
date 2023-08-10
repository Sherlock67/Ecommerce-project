using Microsoft.EntityFrameworkCore;
using pandacommerce_dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_dal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {



        }

        public DbSet<NavCategory> navCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> productCategories { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}
