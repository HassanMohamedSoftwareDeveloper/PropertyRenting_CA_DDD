using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.District;

internal sealed class GetDistrictsByPageWithSearchSpecification : Specification<DistrictReadModel>, ISpecification<DistrictReadModel>
{
    public GetDistrictsByPageWithSearchSpecification(string Search)
        : base(x => EF.Functions.Like(x.Name, $"%{Search}%") || EF.Functions.Like(x.City.Name, $"%{Search}%") || EF.Functions.Like(x.City.Country.Name, $"%{Search}%"))
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
