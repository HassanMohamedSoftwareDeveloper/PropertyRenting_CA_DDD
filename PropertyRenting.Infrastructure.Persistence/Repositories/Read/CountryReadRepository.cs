using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Read;

internal sealed class CountryReadRepository : ReadRepository<CountryReadModel>, ICountryReadRepository
{
    #region CTORS :
    public CountryReadRepository(PropertyRentingReadContext context) : base(context)
    {
    }
    #endregion

    #region Methods :
    public async Task<List<BaseLookupDTO>> GetNationalitiesLookupAsync(CancellationToken cancellationToken = default)
    {
        return await EntitySet
            .AsNoTracking()
            .OrderBy(x => x.CreatedAt)
            .Select(x => new BaseLookupDTO(x.Id, x.Nationality))
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);
    }
    #endregion
}
