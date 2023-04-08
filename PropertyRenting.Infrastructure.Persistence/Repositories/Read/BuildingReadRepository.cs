using PropertyRenting.Application.Models.Read;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Read;

internal sealed class BuildingReadRepository : ReadRepository<BuildingReadModel>, IBuildingReadRepository
{
    #region CTORS :
    public BuildingReadRepository(PropertyRentingReadContext context) : base(context)
    {
    }
    #endregion
}
