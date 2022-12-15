using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_dal.Model
{
    public class NavCategory
    {
        [Key]
        public int NavCategoryId { get; set; }

        public string NavCategoryName { get; set; }
    }
}
