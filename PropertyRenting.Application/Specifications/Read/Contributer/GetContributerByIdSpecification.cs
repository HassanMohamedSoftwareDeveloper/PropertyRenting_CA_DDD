using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Contributer;

internal sealed class GetContributerByIdSpecification : Specification<ContributerReadModel>, ISpecification<ContributerReadModel>
{
    public GetContributerByIdSpecification(Guid Id) : base(x => x.Id == Id)
    {
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
