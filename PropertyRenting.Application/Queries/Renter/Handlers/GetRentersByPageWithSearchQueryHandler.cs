using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Renter;

namespace PropertyRenting.Application.Queries.Renter.Handlers;

internal sealed class GetRentersByPageWithSearchQueryHandler : IRequestHandler<GetRentersByPageWithSearchQuery, ErrorOr<PagedList<RenterReadDTO>>>
{
    private readonly IRenterReadRepository _renterReadRepository;

    public GetRentersByPageWithSearchQueryHandler(IRenterReadRepository renterReadRepository)
    {
        _renterReadRepository = renterReadRepository;
    }
    public async Task<ErrorOr<PagedList<RenterReadDTO>>> Handle(GetRentersByPageWithSearchQuery request, CancellationToken cancellationToken)
    {
        var data = await _renterReadRepository.GetPageAsync<RenterReadDTO>(new GetRentersByPageWithSearchSpecification(request.SearchValue),
          request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
