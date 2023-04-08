using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Country;

namespace PropertyRenting.Application.Queries.Country.Handlers;

internal sealed class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, ErrorOr<List<CountryDTO>>>
{
    private readonly ICountryReadRepository _countryReadRepository;

    public GetAllCountriesQueryHandler(ICountryReadRepository countryReadRepository)
    {
        _countryReadRepository = countryReadRepository;
    }
    public async Task<ErrorOr<List<CountryDTO>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        var data = await _countryReadRepository.GetAsync<CountryDTO>(new GetCountriesSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
