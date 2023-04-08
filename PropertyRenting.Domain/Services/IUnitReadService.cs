using PropertyRenting.Domain.ValueObjects.Building;
using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Domain.Services;

public interface IUnitReadService
{
    Task<bool> ExistsByUnitNumberAsync(EntityId unitId, UnitNumber unitNumber);
    Task<bool> CanDeleteAsync(EntityId unitId);
}
