using PropertyRenting.Domain.Aggregates;
using PropertyRenting.Domain.Repositories;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Write;

public class EmployeeRepository : WriteRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(PropertyRentingWriteContext context) : base(context)
    {
    }
}
