using PropertyRenting.Application.DTOs;

namespace PropertyRenting.Application.Queries.Country;

public record GetAllCountriesQuery() : IRequest<ErrorOr<List<CountryDTO>>>;
public record GetCountriesLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetCountryByIdQuery(Guid CountryId) : IRequest<ErrorOr<CountryDTO>>;
public record GetCountriesByPageQuery(int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<CountryDTO>>>;
public record GetCountriesByPageWithSearchQuery(string SearchValue, int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<CountryDTO>>>;
public record GetNationalitiesLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
