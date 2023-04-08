namespace PropertyRenting.Application.DTOs;
public record DistrictDTO(Guid DistrictId, string DistrictName, Guid CityId, Guid CountryId);
public record DistrictReadDTO(Guid DistrictId, string DistrictName, string CityName, string CountryName);