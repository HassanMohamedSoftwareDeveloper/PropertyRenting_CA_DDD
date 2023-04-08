namespace PropertyRenting.Application.DTOs;
public record CityDTO(Guid CityId, string CityName, Guid CountryId);
public record CityReadDTO(Guid CityId, string CityName, Guid CountryId, string CountryName);