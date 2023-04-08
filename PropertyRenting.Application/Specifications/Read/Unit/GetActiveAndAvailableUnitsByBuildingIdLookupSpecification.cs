using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Unit;

internal sealed class GetActiveAndAvailableUnitsByBuildingIdLookupSpecification : Specification<UnitReadModel>, ISpecification<UnitReadModel>
{
    public GetActiveAndAvailableUnitsByBuildingIdLookupSpecification(Guid BuildingId)
        : base(x => x.BuildingId == BuildingId && x.IsActive && x.IsRented == false)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
