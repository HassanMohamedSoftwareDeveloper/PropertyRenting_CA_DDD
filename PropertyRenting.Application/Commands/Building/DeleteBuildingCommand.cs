namespace PropertyRenting.Application.Commands.Building;

public record DeleteBuildingCommand(Guid BuildingId) : IRequest<ErrorOr<bool>>;
