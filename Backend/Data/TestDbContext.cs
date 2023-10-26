using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
