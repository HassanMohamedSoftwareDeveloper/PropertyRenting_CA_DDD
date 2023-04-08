using PropertyRenting.Application.Models.Read;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Read;

internal sealed class ContributerReadRepository : ReadRepository<ContributerReadModel>, IContributerReadRepository
{
    #region CTORS :
    public ContributerReadRepository(PropertyRentingReadContext context) : base(context)
    {
    }
    #endregion
}
