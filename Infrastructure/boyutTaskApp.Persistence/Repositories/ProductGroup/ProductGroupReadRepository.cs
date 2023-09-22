using boyutTaskAppAPI.Applicaton.Repositories.ProductGroup;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.ProductGroup
{
    public class ProductGroupReadRepository : ReadRepository<Domain.Entities.ProductGroup>,  IProductGroupReadRepository
    {
        public ProductGroupReadRepository(boyutTaskAppDbContext context) : base(context)
        {
        }
    }
}