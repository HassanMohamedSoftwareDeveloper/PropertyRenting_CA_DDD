using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Renter;

internal sealed class GetRentersSpecification : Specification<RenterReadModel>, ISpecification<RenterReadModel>
{
    public GetRentersSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
