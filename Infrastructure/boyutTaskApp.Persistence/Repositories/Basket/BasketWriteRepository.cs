using boyutTaskAppAPI.Applicaton.Repositories.Basket;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.Basket;

public class BasketWriteRepository : WriteRepository<Domain.Entities.Basket>, IBasketWriteRepository
{
    protected BasketWriteRepository(boyutTaskAppDbContext context) : base(context)
    {
    }
}