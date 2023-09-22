using boyutTaskAppAPI.Applicaton.Repositories.Product;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<Domain.Entities.Product>, IProductReadRepository
    {
        public ProductReadRepository(boyutTaskAppDbContext context) : base(context)
        {
        }
    }
}