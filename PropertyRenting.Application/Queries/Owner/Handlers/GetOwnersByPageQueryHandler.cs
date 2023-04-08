using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Owner;

namespace PropertyRenting.Application.Queries.Owner.Handlers;

internal sealed class GetOwnersByPageQueryHandler : IRequestHandler<GetOwnersByPageQuery, ErrorOr<PagedList<OwnerDTO>>>
{
    private readonly IOwnerReadRepository _ownerReadRepository;

    public GetOwnersByPageQueryHandler(IOwnerReadRepository ownerReadRepository)
    {
        _ownerReadRepository = ownerReadRepository;
    }
    public async Task<ErrorOr<PagedList<OwnerDTO>>> Handle(GetOwnersByPageQuery request, CancellationToken cancellationToken)
    {
        var data = await _ownerReadRepository.GetPageAsync<OwnerDTO>(new GetOwnersByPageSpecification(),
            request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
