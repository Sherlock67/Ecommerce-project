using System.ComponentModel.DataAnnotations;

namespace pandacommerce_dal.Model
{
    public class NavCategory
    {
        [Key]
        public int NavCategoryId { get; set; }

        public string NavCategoryName { get; set; }
    }
}
