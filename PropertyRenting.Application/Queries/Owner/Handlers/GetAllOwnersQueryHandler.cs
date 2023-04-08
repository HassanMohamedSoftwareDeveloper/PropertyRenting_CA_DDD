using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Owner;

namespace PropertyRenting.Application.Queries.Owner.Handlers;

internal sealed class GetAllOwnersQueryHandler : IRequestHandler<GetAllOwnersQuery, ErrorOr<List<OwnerDTO>>>
{
    private readonly IOwnerReadRepository _ownerReadRepository;

    public GetAllOwnersQueryHandler(IOwnerReadRepository ownerReadRepository)
    {
        _ownerReadRepository = ownerReadRepository;
    }
    public async Task<ErrorOr<List<OwnerDTO>>> Handle(GetAllOwnersQuery request, CancellationToken cancellationToken)
    {
        var data = await _ownerReadRepository.GetAsync<OwnerDTO>(new GetOwnersSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
