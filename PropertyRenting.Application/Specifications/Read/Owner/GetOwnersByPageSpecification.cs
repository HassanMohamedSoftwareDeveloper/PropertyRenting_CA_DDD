using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Owner;

internal sealed class GetOwnersByPageSpecification : Specification<OwnerReadModel>, ISpecification<OwnerReadModel>
{
    public GetOwnersByPageSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
