using PropertyRenting.Application.DTOs;

namespace PropertyRenting.Application.Queries.Building;

public record GetAllBuildingsQuery() : IRequest<ErrorOr<List<BuildingReadDTO>>>;
public record GetBuildingsLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetActiveBuildingsLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetBuildingByIdQuery(Guid BuildingId) : IRequest<ErrorOr<BuildingDTO>>;
public record GetBuildingsByPageQuery(int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<BuildingReadDTO>>>;
public record GetBuildingsByPageWithSearchQuery(string SearchValue, int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<BuildingReadDTO>>>;