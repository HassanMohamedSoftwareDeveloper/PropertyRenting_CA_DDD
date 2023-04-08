using PropertyRenting.Application.Models.Read;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Read;

internal sealed class DistrictReadRepository : ReadRepository<DistrictReadModel>, IDistrictReadRepository
{
    #region CTORS :
    public DistrictReadRepository(PropertyRentingReadContext context) : base(context)
    {
    }
    #endregion
}
