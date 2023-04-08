using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Unit;

internal sealed class GetUnitsByPageWithSearchSpecification : Specification<UnitReadModel>, ISpecification<UnitReadModel>
{
    public GetUnitsByPageWithSearchSpecification(string Search)
        : base(x => EF.Functions.Like(x.UnitNumber, $"%{Search}%") || EF.Functions.Like(x.UnitName, $"%{Search}%")
        || EF.Functions.Like(x.Building.Symbol, $"%{Search}%") || EF.Functions.Like(x.Building.Name, $"%{Search}%")
        || EF.Functions.Like(x.Address, $"%{Search}%"))
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
