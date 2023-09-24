using Microsoft.EntityFrameworkCore;
using boyutTaskAppAPI.Domain.Entities.Common;

namespace boyutTaskAppAPI.Applicaton.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
