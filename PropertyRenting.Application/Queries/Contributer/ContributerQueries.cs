using PropertyRenting.Application.DTOs;

namespace PropertyRenting.Application.Queries.Contributer;

public record GetAllContributersQuery() : IRequest<ErrorOr<List<ContributerDTO>>>;
public record GetContributersLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetContributerByIdQuery(Guid ContributerId) : IRequest<ErrorOr<ContributerDTO>>;
public record GetContributersByPageQuery(int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<ContributerDTO>>>;
public record GetContributersByPageWithSearchQuery(string SearchValue, int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<ContributerDTO>>>;