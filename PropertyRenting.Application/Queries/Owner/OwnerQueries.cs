using PropertyRenting.Application.DTOs;

namespace PropertyRenting.Application.Queries.Owner;

public record GetAllOwnersQuery() : IRequest<ErrorOr<List<OwnerDTO>>>;
public record GetOwnersLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetOwnerByIdQuery(Guid OwnerId) : IRequest<ErrorOr<OwnerDTO>>;
public record GetOwnersByPageQuery(int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<OwnerDTO>>>;
public record GetOwnersByPageWithSearchQuery(string SearchValue, int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<OwnerDTO>>>;