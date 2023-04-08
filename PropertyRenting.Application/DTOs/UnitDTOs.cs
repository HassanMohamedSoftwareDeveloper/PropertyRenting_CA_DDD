namespace PropertyRenting.Application.DTOs;

public record UnitDTO(Guid Id, string UnitNumber, string UnitName, Guid BuildingId, bool IsActive, bool IsRented, DateOnly? ReceiveDate, string Address, Guid DistrictId, Guid CityId, Guid CountryId,
                      decimal? AnnualRentAmount, decimal? TotalArea, decimal? RentableArea, bool HasCentralAC, bool HasInternetService, uint? FloorNumber, uint? RoomsNumber,
                      uint? ACsNumber, uint? HallsNumber, uint? PathsNumber, uint? KitchensNumber);

public record UnitReadDTO(Guid Id, string UnitNumber, string UnitName, string BuildingCode, string BuildingName, bool IsActive, bool IsRented, string Address, string District, string City, string Country);
