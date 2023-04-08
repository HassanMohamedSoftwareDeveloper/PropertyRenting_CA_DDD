using PropertyRenting.Domain.Aggregates;
using PropertyRenting.Domain.Repositories;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Write;

public class OwnerRepository : WriteRepository<Owner>, IOwnerRepository
{
    public OwnerRepository(PropertyRentingWriteContext context) : base(context)
    {
    }
}
