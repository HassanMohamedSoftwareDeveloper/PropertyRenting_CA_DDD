namespace PropertyRenting.Application.Commands.Contributer;

public record DeleteContributerCommand(Guid ContributerId) : IRequest<ErrorOr<bool>>;