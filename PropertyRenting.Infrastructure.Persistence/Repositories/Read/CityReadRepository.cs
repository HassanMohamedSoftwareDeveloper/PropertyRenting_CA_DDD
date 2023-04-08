using PropertyRenting.Application.Models.Read;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Read;

internal sealed class CityReadRepository : ReadRepository<CityReadModel>, ICityReadRepository
{
    #region CTORS :
    public CityReadRepository(PropertyRentingReadContext context) : base(context)
    {
    }
    #endregion
}
