using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Renter;

internal sealed class GetRentersByPageWithSearchSpecification : Specification<RenterReadModel>, ISpecification<RenterReadModel>
{
    public GetRentersByPageWithSearchSpecification(string Search)
        : base(x => EF.Functions.Like(x.Name, $"%{Search}%") || EF.Functions.Like(x.Nationality.Nationality, $"%{Search}%"))
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}