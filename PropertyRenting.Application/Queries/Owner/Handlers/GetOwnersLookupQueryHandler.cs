using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Owner;

namespace PropertyRenting.Application.Queries.Owner.Handlers;

internal sealed class GetOwnersLookupQueryHandler : IRequestHandler<GetOwnersLookupQuery, ErrorOr<List<BaseLookupDTO>>>
{
    private readonly IOwnerReadRepository _ownerReadRepository;

    public GetOwnersLookupQueryHandler(IOwnerReadRepository ownerReadRepository)
    {
        _ownerReadRepository = ownerReadRepository;
    }
    public async Task<ErrorOr<List<BaseLookupDTO>>> Handle(GetOwnersLookupQuery request, CancellationToken cancellationToken)
    {
        var data = await _ownerReadRepository.GetLookupAsync<BaseLookupDTO>(new GetOwnersLookupSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
