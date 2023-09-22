using boyutTaskAppAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace boyutTaskAppAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<boyutTaskAppDbContext>
    {
        public boyutTaskAppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<boyutTaskAppDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);

            return new boyutTaskAppDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
