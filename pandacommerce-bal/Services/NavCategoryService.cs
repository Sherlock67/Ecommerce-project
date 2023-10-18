using pandacommerce_bal.IService.INavigations;
using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;

namespace pandacommerce_bal.Services
{

    public class NavCategoryService : INavService
    {
        public readonly INavCategory navCategory;
        public NavCategoryService(INavCategory navCategory)
        {
            this.navCategory = navCategory;
        }
        public async Task<NavCategory> AddNewCategory(NavCategory nav)
        {
            return await navCategory.Create(nav);
        }

        public IEnumerable<NavCategory> GetAllNavigationCategory()
        {
            try
            {
                return navCategory.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteNavigationCategory(int id)
        {

            try
            {
                var cat = navCategory.GetById(id);
                navCategory.Delete(cat);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task UpdateNavigationCategory(NavCategory obj)
        {
            try
            {
                navCategory.Update(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
