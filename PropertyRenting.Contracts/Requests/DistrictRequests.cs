namespace PropertyRenting.Contracts.Requests;

public record CreateDistrictRequest(Guid CountryId, Guid CityId, string DistrictName);
public record UpdateDistrictRequest(Guid CountryId, Guid CityId, Guid DistrictId, string DistrictName);
