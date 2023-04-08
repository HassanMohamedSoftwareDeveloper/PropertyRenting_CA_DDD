namespace PropertyRenting.Contracts.Requests;

public record CreateCityRequest(Guid CountryId, string CityName);
public record UpdateCityRequest(Guid CountryId, Guid CityId, string CityName);
