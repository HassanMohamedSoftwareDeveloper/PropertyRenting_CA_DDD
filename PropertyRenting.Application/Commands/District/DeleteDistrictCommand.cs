namespace PropertyRenting.Application.Commands.District;

public record DeleteDistrictCommand(Guid CountryId, Guid CityId, Guid DistrictId) : IRequest<ErrorOr<bool>>;