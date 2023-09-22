using boyutTaskAppAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using boyutTaskAppAPI.Domain.Entities.Common;

namespace boyutTaskAppAPI.Persistence.Contexts
{
    public class boyutTaskAppDbContext : DbContext
    {
        public boyutTaskAppDbContext(DbContextOptions options) : base(options)
        {
            //IoC Conteiner'da dolduralacak
        }
        public DbSet<User> Users { get; set; } = null!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler uzerinden yapilan degisiklik veya yeni eklenen verinin yakalanmasini saglayan propertiydir. Upgrade operasyonlarin da Track edilen verileri yakaylayip elde etmemizi saglar.

            var datas = ChangeTracker.Entries<TimestampedBaseEntity>();
            foreach (var data in datas)
            {
                    _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedAt = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedAt = DateTime.UtcNow,
                    _ => DateTime.UtcNow

                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
