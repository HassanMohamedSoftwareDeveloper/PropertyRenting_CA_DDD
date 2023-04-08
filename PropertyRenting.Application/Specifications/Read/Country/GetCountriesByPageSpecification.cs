using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Country;

internal sealed class GetCountriesByPageSpecification : Specification<CountryReadModel>, ISpecification<CountryReadModel>
{
    public GetCountriesByPageSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
