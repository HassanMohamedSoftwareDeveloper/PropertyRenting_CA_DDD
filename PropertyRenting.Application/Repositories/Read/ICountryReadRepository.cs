using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Models.Read;

namespace PropertyRenting.Application.Repositories.Read;

public interface ICountryReadRepository : IReadRepository<CountryReadModel>
{
    Task<List<BaseLookupDTO>> GetNationalitiesLookupAsync(CancellationToken cancellationToken = default);
}
