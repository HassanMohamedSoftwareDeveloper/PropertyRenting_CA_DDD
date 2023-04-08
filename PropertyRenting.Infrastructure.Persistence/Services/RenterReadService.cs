using PropertyRenting.Domain.Services;
using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Services;

internal sealed class RenterReadService : BaseReadSevice, IRenterReadService
{
    public RenterReadService(PropertyRentingReadContext context) : base(context)
    {
    }

    public async Task<bool> CanDeleteAsync(EntityId renterId)
    {
        return true;
    }
}
