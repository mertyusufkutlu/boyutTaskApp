using boyutTaskAppAPI.Applicaton.Repositories;
using boyutTaskAppAPI.Applicaton.Repositories.User;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.User
{
    public class UserWriteRepository : WriteRepository<Domain.Entities.User>, IUserWriteRepository
    {
        public UserWriteRepository(boyutTaskAppDbContext context) : base(context)
        {
        }
    }
}


