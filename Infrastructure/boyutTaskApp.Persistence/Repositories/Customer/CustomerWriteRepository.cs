using boyutTaskAppAPI.Applicaton.Repositories.Customer;
using boyutTaskAppAPI.Persistence.Contexts;

namespace boyutTaskAppAPI.Persistence.Repositories.Customer
{
    public class CustomerWriteRepository : WriteRepository<Domain.Entities.Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(boyutTaskAppDbContext context) : base(context)
        {
        }
    }
}