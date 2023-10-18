using System.ComponentModel.DataAnnotations;

namespace pandacommerce_dal.Model
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        public string? ModuleName { get; set; }
        public string? Description { get; set; }
        public string? ModuleIcon { get; set; }
        public string? ModuleColor { get; set; }
        public string? ModulePath { get; set; }
        public int? ModuleSequence { get; set; }
        public bool? IsActive { get; set; }
        public virtual List<Menu>? Menus { get; set; }
    }
}
