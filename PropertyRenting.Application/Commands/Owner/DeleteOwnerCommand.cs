namespace PropertyRenting.Application.Commands.Owner;

public record DeleteOwnerCommand(Guid OwnerId) : IRequest<ErrorOr<bool>>;
