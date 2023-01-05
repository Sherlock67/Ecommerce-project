using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_dal.Model
{
    public class ProductCategory
    {
        [Key]
        public int categoryid { get; set; }

        public string categoryname { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
