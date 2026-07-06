using Ecommerce_Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Backend.Repository
{
    public class CategoryRepository (AppDbContext db):GenericRepository<Category>(db),ICategoryRepository
    {

    }
}