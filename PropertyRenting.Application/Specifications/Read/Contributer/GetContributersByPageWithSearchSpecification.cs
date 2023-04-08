using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Contributer;

internal sealed class GetContributersByPageWithSearchSpecification : Specification<ContributerReadModel>, ISpecification<ContributerReadModel>
{
    public GetContributersByPageWithSearchSpecification(string Search)
        : base(x => EF.Functions.Like(x.Name, $"%{Search}%") || EF.Functions.Like(x.MobileNumber, $"%{Search}%") || EF.Functions.Like(x.Email, $"%{Search}%"))
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
