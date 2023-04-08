using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Owner;

internal sealed class GetOwnersSpecification : Specification<OwnerReadModel>, ISpecification<OwnerReadModel>
{
    public GetOwnersSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
