using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Contributer;

namespace PropertyRenting.Application.Queries.Contributer.Handlers;

internal sealed class GetAllContributersQueryHandler : IRequestHandler<GetAllContributersQuery, ErrorOr<List<ContributerDTO>>>
{
    private readonly IContributerReadRepository _contributerReadRepository;

    public GetAllContributersQueryHandler(IContributerReadRepository contributerReadRepository)
    {
        _contributerReadRepository = contributerReadRepository;
    }
    public async Task<ErrorOr<List<ContributerDTO>>> Handle(GetAllContributersQuery request, CancellationToken cancellationToken)
    {
        var data = await _contributerReadRepository.GetAsync<ContributerDTO>(new GetContributersSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
