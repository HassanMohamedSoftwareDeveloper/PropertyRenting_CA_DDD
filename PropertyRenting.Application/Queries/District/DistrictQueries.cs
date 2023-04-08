using PropertyRenting.Application.DTOs;

namespace PropertyRenting.Application.Queries.District;

public record GetAllDistrictsQuery() : IRequest<ErrorOr<List<DistrictReadDTO>>>;
public record GetDistrictsLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetDistrictsLookupByCityIdQuery(Guid CityId) : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetDistrictByIdQuery(Guid DistrictId) : IRequest<ErrorOr<DistrictDTO>>;
public record GetDistrictsByPageQuery(int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<DistrictReadDTO>>>;
public record GetDistrictsByPageWithSearchQuery(string SearchValue, int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<DistrictReadDTO>>>;