using PropertyRenting.Application.Models.Read;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Read;

internal sealed class OwnerReadRepository : ReadRepository<OwnerReadModel>, IOwnerReadRepository
{
    #region CTORS :
    public OwnerReadRepository(PropertyRentingReadContext context) : base(context)
    {
    }
    #endregion
}
