using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Renter;

namespace PropertyRenting.Application.Queries.Renter.Handlers;

internal sealed class GetRenterByIdQueryHandler : IRequestHandler<GetRenterByIdQuery, ErrorOr<RenterDTO>>
{
    private readonly IRenterReadRepository _renterReadRepository;

    public GetRenterByIdQueryHandler(IRenterReadRepository renterReadRepository)
    {
        _renterReadRepository = renterReadRepository;
    }
    public async Task<ErrorOr<RenterDTO>> Handle(GetRenterByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _renterReadRepository.GetByIdAsync<RenterDTO>(new GetRenterByIdSpecification(request.RenterId), cancellationToken);
        if (data is null) return Errors.Queries.NotFound;
        return data;
    }
}
