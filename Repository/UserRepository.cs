using Ecommerce_Backend.Data;
using Ecommerce_Backend.Model;
using Ecommerce_Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Backend.Repository
{
    public class UserRepository(AppDbContext db) : GenericRepository<User>(db), IUserRepository
    {


        public async Task<User?> GetUserByEmail(string Email)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Email == Email);
        }
     

    }
}
