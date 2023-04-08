using PropertyRenting.Application.DTOs;

namespace PropertyRenting.Application.Queries.Renter;

public record GetAllRentersQuery() : IRequest<ErrorOr<List<RenterReadDTO>>>;
public record GetRentersLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetActiveRentersLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetActiveAndNotBlackListedRentersLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetRenterByIdQuery(Guid RenterId) : IRequest<ErrorOr<RenterDTO>>;
public record GetRentersByPageQuery(int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<RenterReadDTO>>>;
public record GetRentersByPageWithSearchQuery(string SearchValue, int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<RenterReadDTO>>>;