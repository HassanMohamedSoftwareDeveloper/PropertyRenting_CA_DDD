namespace PropertyRenting.Application.Commands.Contributer;

public record AddContributerCommand(string Name, string MobileNumber, string Email) : IRequest<ErrorOr<bool>>;
