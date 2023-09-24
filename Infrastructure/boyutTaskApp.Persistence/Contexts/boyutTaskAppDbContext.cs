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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Basket>()
                .HasKey(x => x.Id);
            
            builder.Entity<Basket>()
                .HasOne(x => x.Order)
                .WithOne(o=>o.Basket)
                .HasForeignKey<Order>(x=>x.Id);
        }

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