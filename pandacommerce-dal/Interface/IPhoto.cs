using pandacommerce_dal.Model;
namespace pandacommerce_dal.Interface
{
    public interface IPhoto<T>
    {
        public Task<T> Create(T entity);
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Product>> GetProducts(int id);
        Task<Photo> GetPhoto(int id);
    }
}
