using System.ComponentModel.DataAnnotations;

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
        public int CategoryId { get; set; }
        public ICollection<ProductCategory> Categories { get; set; }
    }
}
