using boyutTaskAppAPI.Applicaton.Repositories.CustomerBasket;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.CustomerBasket
{
    public class CustomerBasketWriteRepository : WriteRepository<Domain.Entities.CustomerBasket>, ICustomerBasketWriteRepository
    {
        public CustomerBasketWriteRepository(boyutTaskAppDbContext context) : base(context)
        {
        }
    }
}