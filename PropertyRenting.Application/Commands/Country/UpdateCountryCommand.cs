namespace PropertyRenting.Application.Commands.Country;

public record UpdateCountryCommand(Guid CountryId, string Name, string Nationality) : IRequest<ErrorOr<bool>>;
