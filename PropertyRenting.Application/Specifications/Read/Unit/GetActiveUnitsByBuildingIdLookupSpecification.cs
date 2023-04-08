using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Unit;

internal sealed class GetActiveUnitsByBuildingIdLookupSpecification : Specification<UnitReadModel>, ISpecification<UnitReadModel>
{
    public GetActiveUnitsByBuildingIdLookupSpecification(Guid BuildingId)
        : base(x => x.BuildingId == BuildingId && x.IsActive)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
