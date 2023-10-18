using System.ComponentModel.DataAnnotations;

namespace pandacommerce_dal.Model
{
    public class ProductCategory
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        
    }
}
