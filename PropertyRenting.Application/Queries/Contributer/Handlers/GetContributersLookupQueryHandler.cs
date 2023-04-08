using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Contributer;

namespace PropertyRenting.Application.Queries.Contributer.Handlers;

internal sealed class GetContributersLookupQueryHandler : IRequestHandler<GetContributersLookupQuery, ErrorOr<List<BaseLookupDTO>>>
{
    private readonly IContributerReadRepository _contributerReadRepository;

    public GetContributersLookupQueryHandler(IContributerReadRepository contributerReadRepository)
    {
        _contributerReadRepository = contributerReadRepository;
    }
    public async Task<ErrorOr<List<BaseLookupDTO>>> Handle(GetContributersLookupQuery request, CancellationToken cancellationToken)
    {
        var data = await _contributerReadRepository.GetLookupAsync<BaseLookupDTO>(new GetContributersLookupSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
