using boyutTaskAppAPI.Applicaton.Repositories.Product;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.Product
{
    public class ProductWriteRepository : WriteRepository<Domain.Entities.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(boyutTaskAppDbContext context) : base(context)
        {
        }
    }
}