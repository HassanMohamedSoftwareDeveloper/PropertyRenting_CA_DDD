using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;
using System.Linq.Expressions;

namespace PropertyRenting.Application.Specifications.Read.Country;

internal sealed class GetCountriesByPageWithSearchSpecification : Specification<CountryReadModel>, ISpecification<CountryReadModel>
{
    public GetCountriesByPageWithSearchSpecification(string Search)
        : base(CreateFilter(Search))
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }

    private static Expression<Func<CountryReadModel, bool>> CreateFilter(string search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return null;
        return x => EF.Functions.Like(x.Name, $"%{search}%") || EF.Functions.Like(x.Nationality, $"%{search}%");
    }
}
