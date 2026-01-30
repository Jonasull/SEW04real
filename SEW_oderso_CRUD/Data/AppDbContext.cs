using Microsoft.EntityFrameworkCore;
using SEW_oderso_CRUD.Models;

namespace SEW_oderso_CRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products => Set<Product>();

        
    }
}
