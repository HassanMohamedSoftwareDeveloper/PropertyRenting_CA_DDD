using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Services;
using PropertyRenting.Domain.ValueObjects.Building;
using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Services;

internal sealed class UnitReadService : BaseReadSevice, IUnitReadService
{
    public UnitReadService(PropertyRentingReadContext context) : base(context)
    {
    }

    public async Task<bool> CanDeleteAsync(EntityId unitId)
    {
        return true;
    }

    public async Task<bool> ExistsByUnitNumberAsync(EntityId unitId, UnitNumber unitNumber)
    {
        return await Context.Set<UnitReadModel>()
         .AnyAsync(x => (unitId == null || x.Id != unitId.Value) && EF.Functions.Like(x.UnitNumber, unitNumber.Value));
    }
}
