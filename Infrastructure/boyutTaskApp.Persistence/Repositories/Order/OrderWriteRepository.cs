using boyutTaskAppAPI.Applicaton.Repositories.Order;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.Order
{
    public class OrderWriteRepository : WriteRepository<Domain.Entities.Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(boyutTaskAppDbContext context) : base(context)
        {
        }
    }
}