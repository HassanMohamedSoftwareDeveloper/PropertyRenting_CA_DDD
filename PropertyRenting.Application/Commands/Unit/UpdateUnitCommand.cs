﻿namespace PropertyRenting.Application.Commands.Unit;

public record UpdateUnitCommand(Guid BuildingId,
                                Guid UnitId,
                                string UnitNumber,
                                string UnitName,
                                bool IsActive,
                                bool IsRented,
                                DateOnly? ReceiveDate,
                                Guid DistrictId,
                                string Address,
                                decimal? AnnualRentAmount,
                                decimal? TotalArea,
                                decimal? RentableArea,
                                bool HasCentralAC,
                                bool HasInternetService,
                                uint? FloorNumber,
                                uint? RoomsNumber,
                                uint? ACsNumber,
                                uint? HallsNumber,
                                uint? PathsNumber,
                                uint? KitchensNumber) : IRequest<ErrorOr<bool>>;