namespace PropertyRenting.Application.Commands.Country;

public record DeleteCountryCommand(Guid CountryId) : IRequest<ErrorOr<bool>>;