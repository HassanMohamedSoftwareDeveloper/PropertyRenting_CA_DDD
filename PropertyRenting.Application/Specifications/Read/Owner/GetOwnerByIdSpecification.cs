using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Owner;

internal sealed class GetOwnerByIdSpecification : Specification<OwnerReadModel>, ISpecification<OwnerReadModel>
{
    public GetOwnerByIdSpecification(Guid Id) : base(x => x.Id == Id)
    {
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
