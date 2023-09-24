using boyutTaskAppAPI.Applicaton.Repositories;
using boyutTaskAppAPI.Applicaton.Repositories.User;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.User
{
    public class UserReadRepository : ReadRepository<Domain.Entities.User>, IUserReadRepository
    {
        public UserReadRepository(boyutTaskAppDbContext context) : base(context)
        {
        }
    }
}
