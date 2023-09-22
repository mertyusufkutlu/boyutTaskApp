using boyutTaskAppAPI.Applicaton.Repositories.Order;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<Domain.Entities.Order>, IOrderReadRepository
    {
        public OrderReadRepository(boyutTaskAppDbContext context) : base(context)
        {
        }
    }
}