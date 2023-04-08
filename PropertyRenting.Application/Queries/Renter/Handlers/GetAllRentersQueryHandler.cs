using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Renter;

namespace PropertyRenting.Application.Queries.Renter.Handlers;

internal sealed class GetAllRentersQueryHandler : IRequestHandler<GetAllRentersQuery, ErrorOr<List<RenterReadDTO>>>
{
    private readonly IRenterReadRepository _renterReadRepository;

    public GetAllRentersQueryHandler(IRenterReadRepository renterReadRepository)
    {
        _renterReadRepository = renterReadRepository;
    }
    public async Task<ErrorOr<List<RenterReadDTO>>> Handle(GetAllRentersQuery request, CancellationToken cancellationToken)
    {
        var data = await _renterReadRepository.GetAsync<RenterReadDTO>(new GetRentersSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
