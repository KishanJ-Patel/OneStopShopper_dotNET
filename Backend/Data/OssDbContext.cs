using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class OssDbContext : DbContext
    {   
        public OssDbContext(DbContextOptions<OssDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }

}
