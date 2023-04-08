using PropertyRenting.Domain.Aggregates;
using PropertyRenting.Domain.Repositories;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Write;

public class RenterRepository : WriteRepository<Renter>, IRenterRepository
{
    public RenterRepository(PropertyRentingWriteContext context) : base(context)
    {
    }
}