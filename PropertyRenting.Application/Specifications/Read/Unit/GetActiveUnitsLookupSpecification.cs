using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;
using System.Linq.Expressions;

namespace PropertyRenting.Application.Specifications.Read.Unit;

internal sealed class GetActiveUnitsLookupSpecification : Specification<UnitReadModel>, ISpecification<UnitReadModel>
{
    private static readonly Expression<Func<UnitReadModel, bool>> _criteria = x => x.IsActive;
    public GetActiveUnitsLookupSpecification() : base(_criteria)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
