using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Write.Building;

internal sealed class GetBuildingWithUnitsSpecification : Specification<Domain.Aggregates.Building>, ISpecification<Domain.Aggregates.Building>
{
    public GetBuildingWithUnitsSpecification(EntityId buildingId) : base(x => x.Id == buildingId)
    {
        AddInclude(x => x.Units);
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
    }
}
