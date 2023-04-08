namespace PropertyRenting.Application.Commands.Owner;

public record UpdateOwnerCommand(Guid OwnerId, string Name, string MobileNumber, string Email) : IRequest<ErrorOr<bool>>;
