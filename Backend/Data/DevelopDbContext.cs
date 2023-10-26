using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class DevelopDbContext : DbContext
    {   
        public DevelopDbContext(DbContextOptions<DevelopDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }

}
