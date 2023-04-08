using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Contributer;

namespace PropertyRenting.Application.Queries.Contributer.Handlers;

internal sealed class GetContributersByPageWithSearchQueryHandler : IRequestHandler<GetContributersByPageWithSearchQuery, ErrorOr<PagedList<ContributerDTO>>>
{
    private readonly IContributerReadRepository _contributerReadRepository;

    public GetContributersByPageWithSearchQueryHandler(IContributerReadRepository contributerReadRepository)
    {
        _contributerReadRepository = contributerReadRepository;
    }
    public async Task<ErrorOr<PagedList<ContributerDTO>>> Handle(GetContributersByPageWithSearchQuery request, CancellationToken cancellationToken)
    {
        var data = await _contributerReadRepository.GetPageAsync<ContributerDTO>(new GetContributersByPageWithSearchSpecification(request.SearchValue),
            request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
