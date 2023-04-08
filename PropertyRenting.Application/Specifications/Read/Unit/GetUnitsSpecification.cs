using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Unit;

internal sealed class GetUnitsSpecification : Specification<UnitReadModel>, ISpecification<UnitReadModel>
{
    public GetUnitsSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
