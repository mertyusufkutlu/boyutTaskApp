using boyutTaskAppAPI.Applicaton.Repositories.BasketItems;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.BasketItem;

public class BasketItemReadRepository : ReadRepository<Domain.Entities.BasketItem> , IBasketItemReadRepository
{
    protected BasketItemReadRepository(boyutTaskAppDbContext context) : base(context)
    {
    }
}