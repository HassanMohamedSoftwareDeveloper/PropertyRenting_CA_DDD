using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;
using System.Linq.Expressions;

namespace PropertyRenting.Application.Specifications.Read.Renter;

internal sealed class GetActiveAndNotBlackListedRentersLookupSpecification : Specification<RenterReadModel>, ISpecification<RenterReadModel>
{
    private static readonly Expression<Func<RenterReadModel, bool>> _criteria = x => x.IsActive && x.IsBlackListed == false;
    public GetActiveAndNotBlackListedRentersLookupSpecification() : base(_criteria)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
