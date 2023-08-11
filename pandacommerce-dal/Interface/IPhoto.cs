using pandacommerce_dal.Model;
namespace pandacommerce_dal.Interface
{
    public interface IPhoto
    {
        void Add<T> (T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Product>> GetProducts(int id);
        Task<Photo> GetPhoto(int id);
    }
}
