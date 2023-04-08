using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Renter;

namespace PropertyRenting.Application.Queries.Renter.Handlers;

internal sealed class GetRentersByPageQueryHandler : IRequestHandler<GetRentersByPageQuery, ErrorOr<PagedList<RenterReadDTO>>>
{
    private readonly IRenterReadRepository _renterReadRepository;

    public GetRentersByPageQueryHandler(IRenterReadRepository renterReadRepository)
    {
        _renterReadRepository = renterReadRepository;
    }
    public async Task<ErrorOr<PagedList<RenterReadDTO>>> Handle(GetRentersByPageQuery request, CancellationToken cancellationToken)
    {
        var data = await _renterReadRepository.GetPageAsync<RenterReadDTO>(new GetRentersByPageSpecification(),
            request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
