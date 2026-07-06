namespace Ecommerce_Backend.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entiry);
        Task<T?> GetById(int id);
        Task<List<T>> GetAll();
        Task<bool> SaveChange();
    }
}