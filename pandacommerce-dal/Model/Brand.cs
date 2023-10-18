using System.ComponentModel.DataAnnotations;

namespace pandacommerce_dal.Model
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }   
        public string BrandDescription { get; set; }
    }
}
