using Ecommerce_Backend.Model;

namespace Ecommerce_Backend.Repository.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
       
      
        Task<User?> GetUserByEmail(string Email);
     
    }
}
