using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.District;

internal sealed class GetDistrictsLookupSpecification : Specification<DistrictReadModel>, ISpecification<DistrictReadModel>
{
    public GetDistrictsLookupSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
