using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Building;

internal sealed class GetBuildingsByPageSpecification : Specification<BuildingReadModel>, ISpecification<BuildingReadModel>
{
    public GetBuildingsByPageSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        AsNoTracking = true;
        IsSplitQuery = true;
    }
}
