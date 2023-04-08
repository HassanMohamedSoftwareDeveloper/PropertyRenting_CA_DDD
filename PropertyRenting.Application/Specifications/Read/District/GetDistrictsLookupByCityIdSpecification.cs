using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.District;

internal sealed class GetDistrictsLookupByCityIdSpecification : Specification<DistrictReadModel>, ISpecification<DistrictReadModel>
{
    public GetDistrictsLookupByCityIdSpecification(Guid CityId) : base(x => x.CityId == CityId)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}