namespace PropertyRenting.Application.DTOs;

public record BuildingDTO(Guid Id, string Symbol, string Name, bool IsActive, int Type, Guid EmployeeId, Guid DistrictId, Guid CityId, Guid CountryId, string Address, string Location,
                          string Latitude, string Longitude, int ConstructionStatus, int? EstablishYear, decimal? TotalArea, decimal? RentableArea, decimal? YearRentAmount,
                          decimal? YearReRentAmount, int? LevelsNumber, DateOnly? ReceiveDate, string Notes, List<BuildingContributerDTO> Contributers);
public record BuildingContributerDTO(Guid Id, Guid ContributerId, decimal Percentage);

public record BuildingReadDTO(Guid Id, string Symbol, string Name, bool IsActive, string Type, string Employee, string Address, string District, string City, string Country, string ConstructionStatus, int? UnitsNumber);