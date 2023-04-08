using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Contributer;

namespace PropertyRenting.Application.Queries.Contributer.Handlers;

internal sealed class GetContributerByIdQueryHandler : IRequestHandler<GetContributerByIdQuery, ErrorOr<ContributerDTO>>
{
    private readonly IContributerReadRepository _contributerReadRepository;

    public GetContributerByIdQueryHandler(IContributerReadRepository contributerReadRepository)
    {
        _contributerReadRepository = contributerReadRepository;
    }
    public async Task<ErrorOr<ContributerDTO>> Handle(GetContributerByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _contributerReadRepository.GetByIdAsync<ContributerDTO>(new GetContributerByIdSpecification(request.ContributerId), cancellationToken);
        if (data is null) return Errors.Queries.NotFound;
        return data;
    }
}
