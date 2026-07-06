using Ecommerce_Backend.Data;
using Ecommerce_Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Backend
{
    public class GenericRepository<T>(AppDbContext db) : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> model = db.Set<T>();

        public async Task Add(T entity)
        {
            await model.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            model.Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await model.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await model.FindAsync(id);
        }

        public async Task<bool> SaveChange()
        {
            return await db.SaveChangesAsync() > 0;
        }

        public void Update(T entity)
        {
            model.Update(entity);
        }
    }
}