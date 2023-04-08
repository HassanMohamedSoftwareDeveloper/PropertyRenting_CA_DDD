using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Country;

namespace PropertyRenting.Application.Queries.Country.Handlers;

internal sealed class GetCountriesLookupQueryHandler : IRequestHandler<GetCountriesLookupQuery, ErrorOr<List<BaseLookupDTO>>>
{
    private readonly ICountryReadRepository _countryReadRepository;

    public GetCountriesLookupQueryHandler(ICountryReadRepository countryReadRepository)
    {
        _countryReadRepository = countryReadRepository;
    }

    public async Task<ErrorOr<List<BaseLookupDTO>>> Handle(GetCountriesLookupQuery request, CancellationToken cancellationToken)
    {
        var data = await _countryReadRepository.GetLookupAsync<BaseLookupDTO>(new GetCountriesLookupSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
