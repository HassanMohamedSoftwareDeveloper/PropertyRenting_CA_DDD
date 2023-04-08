namespace PropertyRenting.Application.Commands.District;

public record UpdateDistrictCommand(Guid CountryId, Guid CityId, Guid DistrictId, string Name) : IRequest<ErrorOr<bool>>;
