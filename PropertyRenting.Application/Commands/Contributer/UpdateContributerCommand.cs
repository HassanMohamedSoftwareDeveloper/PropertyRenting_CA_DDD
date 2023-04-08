namespace PropertyRenting.Application.Commands.Contributer;

public record UpdateContributerCommand(Guid ContributerId, string Name, string MobileNumber, string Email) : IRequest<ErrorOr<bool>>;
