using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Building;

internal sealed class GetBuildingsByPageWithSearchSpecification : Specification<BuildingReadModel>, ISpecification<BuildingReadModel>
{
    public GetBuildingsByPageWithSearchSpecification(string Search)
        : base(x => EF.Functions.Like(x.Symbol, $"%{Search}%") || EF.Functions.Like(x.Name, $"%{Search}%"))
    {
        AddOrderBy(x => x.CreatedAt);
        AsNoTracking = true;
        IsSplitQuery = true;
    }
}