using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Country;

namespace PropertyRenting.Application.Queries.Country.Handlers;

internal sealed class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, ErrorOr<CountryDTO>>
{
    private readonly ICountryReadRepository _countryReadRepository;

    public GetCountryByIdQueryHandler(ICountryReadRepository countryReadRepository)
    {
        _countryReadRepository = countryReadRepository;
    }
    public async Task<ErrorOr<CountryDTO>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _countryReadRepository.GetByIdAsync<CountryDTO>(new GetCountryByIdSpecification(request.CountryId), cancellationToken);
        if (data is null) return Errors.Queries.NotFound;
        return data;
    }
}
