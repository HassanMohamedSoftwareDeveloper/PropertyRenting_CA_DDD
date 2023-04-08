using PropertyRenting.Application.DTOs;

namespace PropertyRenting.Application.Queries.Unit;

public record GetAllUnitsQuery() : IRequest<ErrorOr<List<UnitReadDTO>>>;
public record GetUnitsLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetActiveUnitsLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetActiveUnitsByBuildingIdLookupQuery(Guid BuildingId) : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetActiveAndAvailableUnitsByBuildingIdLookupQuery(Guid BuildingId) : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetUnitByIdQuery(Guid UnitId) : IRequest<ErrorOr<UnitDTO>>;
public record GetUnitsByPageQuery(int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<UnitReadDTO>>>;
public record GetUnitsByPageWithSearchQuery(string SearchValue, int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<UnitReadDTO>>>;