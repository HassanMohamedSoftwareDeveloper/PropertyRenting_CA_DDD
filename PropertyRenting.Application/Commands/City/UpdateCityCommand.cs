namespace PropertyRenting.Application.Commands.City;

public record UpdateCityCommand(Guid CountryId, Guid CityId, string Name) : IRequest<ErrorOr<bool>>;
