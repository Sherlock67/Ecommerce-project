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
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        
    }
}
