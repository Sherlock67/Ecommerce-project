using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_dal.Model
{
    public class Product
    {
        [Key]
        public int product_Id { get; set; }
        public string? product_name { get; set; }

        public string short_description { get; set; }

        public string full_description { get; set; }
        public int price { get; set; }
        public int categoryid { get; set; }
       // public ProductCategory productcategories { get; set; }
       

    }
}
