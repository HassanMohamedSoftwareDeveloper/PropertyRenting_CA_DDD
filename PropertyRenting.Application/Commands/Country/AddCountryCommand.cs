namespace PropertyRenting.Application.Commands.Country;

public record AddCountryCommand(string Name, string Nationality) : IRequest<ErrorOr<bool>>;
