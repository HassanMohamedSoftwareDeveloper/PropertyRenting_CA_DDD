using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;
using System.Linq.Expressions;

namespace PropertyRenting.Application.Specifications.Read.Building;

internal sealed class GetActiveBuildingsLookupSpecification : Specification<BuildingReadModel>, ISpecification<BuildingReadModel>
{
    private static readonly Expression<Func<BuildingReadModel, bool>> _criteria = x => x.IsActive;
    public GetActiveBuildingsLookupSpecification() : base(_criteria)
    {
        AddOrderBy(x => x.CreatedAt);
        AsNoTracking = true;
        IsSplitQuery = true;
    }
}
