using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Country;

namespace PropertyRenting.Application.Queries.Country.Handlers;

internal sealed class GetCountriesByPageQueryHandler : IRequestHandler<GetCountriesByPageQuery, ErrorOr<PagedList<CountryDTO>>>
{
    private readonly ICountryReadRepository _countryReadRepository;

    public GetCountriesByPageQueryHandler(ICountryReadRepository countryReadRepository)
    {
        _countryReadRepository = countryReadRepository;
    }
    public async Task<ErrorOr<PagedList<CountryDTO>>> Handle(GetCountriesByPageQuery request, CancellationToken cancellationToken)
    {
        var data = await _countryReadRepository.GetPageAsync<CountryDTO>(new GetCountriesByPageSpecification(),
           request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
