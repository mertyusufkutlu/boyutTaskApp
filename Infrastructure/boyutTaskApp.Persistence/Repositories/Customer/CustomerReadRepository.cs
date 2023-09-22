using boyutTaskAppAPI.Applicaton.Repositories.Customer;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.Customer

{
    public class CustomerReadRepository : ReadRepository<Domain.Entities.Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(boyutTaskAppDbContext context) : base(context)
        {
        }
    }
}