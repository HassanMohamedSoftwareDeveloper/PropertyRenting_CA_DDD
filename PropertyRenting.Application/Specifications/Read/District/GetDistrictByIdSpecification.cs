using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.District;

internal sealed class GetDistrictByIdSpecification : Specification<DistrictReadModel>, ISpecification<DistrictReadModel>
{
    public GetDistrictByIdSpecification(Guid Id) : base(x => x.Id == Id)
    {
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
