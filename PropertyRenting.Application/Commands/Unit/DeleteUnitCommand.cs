namespace PropertyRenting.Application.Commands.Unit;

public record DeleteUnitCommand(Guid BuildingId, Guid UnitId) : IRequest<ErrorOr<bool>>;
