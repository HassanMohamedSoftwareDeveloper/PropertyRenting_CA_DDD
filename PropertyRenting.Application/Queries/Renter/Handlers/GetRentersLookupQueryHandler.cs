using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Renter;

namespace PropertyRenting.Application.Queries.Renter.Handlers;

internal sealed class GetRentersLookupQueryHandler : IRequestHandler<GetRentersLookupQuery, ErrorOr<List<BaseLookupDTO>>>
{
    private readonly IRenterReadRepository _renterReadRepository;

    public GetRentersLookupQueryHandler(IRenterReadRepository renterReadRepository)
    {
        _renterReadRepository = renterReadRepository;
    }
    public async Task<ErrorOr<List<BaseLookupDTO>>> Handle(GetRentersLookupQuery request, CancellationToken cancellationToken)
    {
        var data = await _renterReadRepository.GetLookupAsync<BaseLookupDTO>(new GetRentersLookupSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
