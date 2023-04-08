using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Services;
using PropertyRenting.Domain.ValueObjects.Building;
using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Services;

internal sealed class BuildingReadService : BaseReadSevice, IBuildingReadService
{
    public BuildingReadService(PropertyRentingReadContext context) : base(context)
    {
    }

    public async Task<bool> ExistsBySymbolAsync(EntityId buildingId, BuildingSymbol symbol)
    {
        return await Context.Set<BuildingReadModel>()
            .AnyAsync(x => (buildingId == null || x.Id != buildingId.Value) && EF.Functions.Like(x.Symbol, symbol.Value));
    }

    public async Task<bool> CanDeleteAsync(EntityId buildingId)
    {
        return true;
    }
}
