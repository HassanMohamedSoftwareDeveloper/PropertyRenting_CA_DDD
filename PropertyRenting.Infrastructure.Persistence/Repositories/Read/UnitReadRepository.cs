using PropertyRenting.Application.Models.Read;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Read;

internal sealed class UnitReadRepository : ReadRepository<UnitReadModel>, IUnitReadRepository
{
    #region CTORS :
    public UnitReadRepository(PropertyRentingReadContext context) : base(context)
    {
    }
    #endregion
}
