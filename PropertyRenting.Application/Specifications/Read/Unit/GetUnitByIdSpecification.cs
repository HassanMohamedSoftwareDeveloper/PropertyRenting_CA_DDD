using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Unit;

internal sealed class GetUnitByIdSpecification : Specification<UnitReadModel>, ISpecification<UnitReadModel>
{
    public GetUnitByIdSpecification(Guid Id) : base(x => x.Id == Id)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
