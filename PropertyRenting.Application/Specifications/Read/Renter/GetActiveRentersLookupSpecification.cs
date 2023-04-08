using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;
using System.Linq.Expressions;

namespace PropertyRenting.Application.Specifications.Read.Renter;

internal sealed class GetActiveRentersLookupSpecification : Specification<RenterReadModel>, ISpecification<RenterReadModel>
{
    private static readonly Expression<Func<RenterReadModel, bool>> _criteria = x => x.IsActive;
    public GetActiveRentersLookupSpecification() : base(_criteria)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
