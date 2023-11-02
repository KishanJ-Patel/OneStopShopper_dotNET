using Microsoft.EntityFrameworkCore;
using Backend.Data;

namespace UnitTests.TestDbFixtures
{
    public class ControllersTestDbFixture
    {
        private const string ConnectionString
            = "Data Source=GALACTON\\ONESTOPSHOPPER;Database=DevelopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public OssDbContext CreateContext()
            => new(new DbContextOptionsBuilder<OssDbContext>().UseSqlServer(ConnectionString).Options);
    }
}
