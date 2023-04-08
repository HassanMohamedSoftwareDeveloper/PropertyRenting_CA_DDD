using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Contributer;

namespace PropertyRenting.Application.Queries.Contributer.Handlers;

internal sealed class GetContributersByPageQueryHandler : IRequestHandler<GetContributersByPageQuery, ErrorOr<PagedList<ContributerDTO>>>
{
    private readonly IContributerReadRepository _contributerReadRepository;

    public GetContributersByPageQueryHandler(IContributerReadRepository contributerReadRepository)
    {
        _contributerReadRepository = contributerReadRepository;
    }
    public async Task<ErrorOr<PagedList<ContributerDTO>>> Handle(GetContributersByPageQuery request, CancellationToken cancellationToken)
    {
        var data = await _contributerReadRepository.GetPageAsync<ContributerDTO>(new GetContributersByPageSpecification(), request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
