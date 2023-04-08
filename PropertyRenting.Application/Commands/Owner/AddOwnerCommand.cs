namespace PropertyRenting.Application.Commands.Owner;

public record AddOwnerCommand(string Name, string MobileNumber, string Email) : IRequest<ErrorOr<bool>>;
