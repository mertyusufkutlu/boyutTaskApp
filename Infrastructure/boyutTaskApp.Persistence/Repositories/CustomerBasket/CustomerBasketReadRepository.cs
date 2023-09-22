using boyutTaskAppAPI.Applicaton.Repositories.CustomerBasket;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.CustomerBasket
{
    public class CustomerBasketReadRepository : ReadRepository<Domain.Entities.CustomerBasket>, ICustomerBasketReadRepository
    {
        public CustomerBasketReadRepository(boyutTaskAppDbContext context) : base(context)
        {
        }
    }
}