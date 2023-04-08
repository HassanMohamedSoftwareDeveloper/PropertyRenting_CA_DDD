using PropertyRenting.Domain.ValueObjects.Building;
using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Domain.Services;

public interface IBuildingReadService
{
    Task<bool> ExistsBySymbolAsync(EntityId buildingId, BuildingSymbol symbol);
    Task<bool> CanDeleteAsync(EntityId buildingId);

}
