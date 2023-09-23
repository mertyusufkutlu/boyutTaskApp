using boyutTaskAppAPI.Applicaton.Repositories.Basket;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.Basket;

public class BasketReadRepository : ReadRepository<Domain.Entities.Basket>, IBasketReadRepository
{
    protected BasketReadRepository(boyutTaskAppDbContext context) : base(context)
    {
    }
}