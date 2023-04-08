namespace PropertyRenting.Application.Commands.City;

public record DeleteCityCommand(Guid CountryId, Guid CityId) : IRequest<ErrorOr<bool>>;