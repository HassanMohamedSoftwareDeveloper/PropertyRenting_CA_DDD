using PropertyRenting.Domain.Aggregates;
using PropertyRenting.Domain.Repositories;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Write;

public class ContributerRepository : WriteRepository<Contributer>, IContributerRepository
{
    public ContributerRepository(PropertyRentingWriteContext context) : base(context)
    {
    }
}
