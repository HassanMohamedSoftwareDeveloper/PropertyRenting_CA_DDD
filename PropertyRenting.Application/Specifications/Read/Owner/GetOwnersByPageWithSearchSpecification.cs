using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Owner;

internal sealed class GetOwnersByPageWithSearchSpecification : Specification<OwnerReadModel>, ISpecification<OwnerReadModel>
{
    public GetOwnersByPageWithSearchSpecification(string Search)
        : base(x => EF.Functions.Like(x.Name, $"%{Search}%") || EF.Functions.Like(x.MobileNumber, $"%{Search}%") || EF.Functions.Like(x.Email, $"%{Search}%"))
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
