using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Owner;

namespace PropertyRenting.Application.Queries.Owner.Handlers;

internal sealed class GetOwnersByPageWithSearchQueryHandler : IRequestHandler<GetOwnersByPageWithSearchQuery, ErrorOr<PagedList<OwnerDTO>>>
{
    private readonly IOwnerReadRepository _ownerReadRepository;

    public GetOwnersByPageWithSearchQueryHandler(IOwnerReadRepository ownerReadRepository)
    {
        _ownerReadRepository = ownerReadRepository;
    }
    public async Task<ErrorOr<PagedList<OwnerDTO>>> Handle(GetOwnersByPageWithSearchQuery request, CancellationToken cancellationToken)
    {
        var data = await _ownerReadRepository.GetPageAsync<OwnerDTO>(new GetOwnersByPageWithSearchSpecification(request.SearchValue),
            request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
