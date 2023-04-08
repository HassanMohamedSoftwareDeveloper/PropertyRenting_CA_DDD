using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Contributer;

internal sealed class GetContributersByPageSpecification : Specification<ContributerReadModel>, ISpecification<ContributerReadModel>
{
    public GetContributersByPageSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
