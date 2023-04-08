namespace PropertyRenting.Application.Commands.City;

public record AddCityCommand(Guid CountryId, string Name) : IRequest<ErrorOr<bool>>;
