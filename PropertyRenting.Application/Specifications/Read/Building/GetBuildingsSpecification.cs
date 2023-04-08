using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Building;

internal sealed class GetBuildingsSpecification : Specification<BuildingReadModel>, ISpecification<BuildingReadModel>
{
    public GetBuildingsSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        AsNoTracking = true;
        IsSplitQuery = true;
    }
}
