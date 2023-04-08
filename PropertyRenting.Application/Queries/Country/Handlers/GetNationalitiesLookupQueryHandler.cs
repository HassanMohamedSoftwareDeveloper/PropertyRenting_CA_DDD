using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;

namespace PropertyRenting.Application.Queries.Country.Handlers;

internal sealed class GetNationalitiesLookupQueryHandler : IRequestHandler<GetNationalitiesLookupQuery, ErrorOr<List<BaseLookupDTO>>>
{
    private readonly ICountryReadRepository _countryReadRepository;

    public GetNationalitiesLookupQueryHandler(ICountryReadRepository countryReadRepository)
    {
        _countryReadRepository = countryReadRepository;
    }
    public async Task<ErrorOr<List<BaseLookupDTO>>> Handle(GetNationalitiesLookupQuery request, CancellationToken cancellationToken)
    {
        var data = await _countryReadRepository.GetNationalitiesLookupAsync(cancellationToken);
        if (data == null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
