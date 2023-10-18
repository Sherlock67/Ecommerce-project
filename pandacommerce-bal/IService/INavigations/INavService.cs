using pandacommerce_dal.Model;

namespace pandacommerce_bal.IService.INavigations
{
    public interface INavService 
    {
        public Task<NavCategory> AddNewCategory(NavCategory entity);
        public IEnumerable<NavCategory> GetAllNavigationCategory();
    }
}
