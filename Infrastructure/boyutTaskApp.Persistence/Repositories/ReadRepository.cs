using boyutTaskAppAPI.Applicaton.Repositories;
using boyutTaskAppAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using boyutTaskAppAPI.Domain.Entities.Common;

namespace boyutTaskAppAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly boyutTaskAppDbContext _context;

        protected ReadRepository(boyutTaskAppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool traking = true)
        {
            var query = Table.AsQueryable();
            if (!traking)
                query = query.AsNoTracking();
            return (query);

        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool traking = true)
        {
           var query = Table.Where(method);
            if (!traking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool traking = true)
        {
            var query = Table.AsQueryable();
            if (!traking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public async Task<Domain.Entities.User?> GetDbUser(string phoneNumber, bool traking = true)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
            return user;
        }


        public async Task<T> GetByIdAsync(string id, bool traking = true)
        // => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        // => await Table.FindAsync(Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (!traking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));

        } 
    }

}