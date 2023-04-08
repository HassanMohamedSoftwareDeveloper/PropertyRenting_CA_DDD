using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.District;

internal sealed class GetDistrictsSpecification : Specification<DistrictReadModel>, ISpecification<DistrictReadModel>
{
    public GetDistrictsSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
