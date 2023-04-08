using PropertyRenting.Application.Models.Read;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Read;

internal sealed class EmployeeReadRepository : ReadRepository<EmployeeReadModel>, IEmployeeReadRepository
{
    #region CTORS :
    public EmployeeReadRepository(PropertyRentingReadContext context) : base(context)
    {
    }
    #endregion
}
