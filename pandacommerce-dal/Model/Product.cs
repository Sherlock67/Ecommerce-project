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
        public int ProductId { get; set; }    
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string BrandName { get; set; }
        public int Price { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
