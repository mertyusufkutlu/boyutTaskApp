using boyutTaskAppAPI.Applicaton.Repositories.ProductGroup;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.ProductGroup
{
    public class ProductGroupWriteRepository : WriteRepository<Domain.Entities.ProductGroup>,  IProductGroupWriteRepository
    {
        public ProductGroupWriteRepository(boyutTaskAppDbContext context) : base(context)
        {
        }
    }
}