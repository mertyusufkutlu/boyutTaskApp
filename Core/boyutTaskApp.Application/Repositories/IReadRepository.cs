using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using boyutTaskAppAPI.Domain.Entities;
using boyutTaskAppAPI.Domain.Entities.Common;

namespace boyutTaskAppAPI.Applicaton.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool traking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool traking = true);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool traking = true);
        
        Task<User?> GetDbUser(string phoneNumber, string? requestEmail, bool traking = true);
        
        Task<bool> UserExists(string phoneNumber, string? requestEmail, bool traking = true);
        Task<T> GetByIdAsync(string id, bool traking = true);
    }
}
