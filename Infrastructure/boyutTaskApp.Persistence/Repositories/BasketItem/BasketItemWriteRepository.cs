using boyutTaskAppAPI.Applicaton.Repositories.BasketItems;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.BasketItem;

public class BasketItemWriteRepository : WriteRepository<Domain.Entities.BasketItem>, IBasketItemWriteRepository
{
    public BasketItemWriteRepository(boyutTaskAppDbContext context) : base(context)
    {
    }
}