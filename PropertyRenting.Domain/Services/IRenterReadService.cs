using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Domain.Services;

public interface IRenterReadService
{
    Task<bool> CanDeleteAsync(EntityId renterId);
}
