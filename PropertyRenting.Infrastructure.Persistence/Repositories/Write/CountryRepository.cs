using Microsoft.EntityFrameworkCore;
using PropertyRenting.Domain.Aggregates;
using PropertyRenting.Domain.Primitives;
using PropertyRenting.Domain.Repositories;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Write;

public class CountryRepository : WriteRepository<Country>, ICountryRepository
{
    public CountryRepository(PropertyRentingWriteContext context) : base(context)
    {
    }

    public async Task<Country> GetCountryAsync(ISpecification<Country> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification)
             .SingleOrDefaultAsync(cancellationToken)
             .ConfigureAwait(false);
    }
}
