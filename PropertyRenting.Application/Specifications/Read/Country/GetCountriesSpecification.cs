using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Country;

internal sealed class GetCountriesSpecification : Specification<CountryReadModel>, ISpecification<CountryReadModel>
{
    public GetCountriesSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
