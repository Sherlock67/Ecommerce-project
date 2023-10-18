using System.ComponentModel.DataAnnotations;

namespace pandacommerce_dal.Model
{
    public class MenuPermission
    {
        [Key]
        public int PermissionId { get; set; }
        public bool? CanCreate { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanView { get; set; }
        public int? MenuId { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public bool? IsActive { get; set; }
        public virtual Menu? Menu { get; set; }
    }
}
