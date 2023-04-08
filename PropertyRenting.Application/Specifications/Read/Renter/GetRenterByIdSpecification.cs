using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Renter;

internal sealed class GetRenterByIdSpecification : Specification<RenterReadModel>, ISpecification<RenterReadModel>
{
    public GetRenterByIdSpecification(Guid Id) : base(x => x.Id == Id)
    {
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
