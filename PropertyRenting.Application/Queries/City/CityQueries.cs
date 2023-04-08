using PropertyRenting.Application.DTOs;

namespace PropertyRenting.Application.Queries.City;

public record GetAllCitiesQuery() : IRequest<ErrorOr<List<CityReadDTO>>>;
public record GetCitiesLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetCitiesLookupByCountryIdQuery(Guid CountryId) : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetCityByIdQuery(Guid CityId) : IRequest<ErrorOr<CityDTO>>;
public record GetCitiesByPageQuery(int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<CityReadDTO>>>;
public record GetCitiesByPageWithSearchQuery(string SearchValue, int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<CityReadDTO>>>;