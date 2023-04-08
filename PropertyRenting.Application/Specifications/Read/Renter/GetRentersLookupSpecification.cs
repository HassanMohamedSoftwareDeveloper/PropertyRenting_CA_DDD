using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Renter;

internal sealed class GetRentersLookupSpecification : Specification<RenterReadModel>, ISpecification<RenterReadModel>
{
    public GetRentersLookupSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
