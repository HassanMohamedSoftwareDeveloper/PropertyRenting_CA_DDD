using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.City;

internal sealed class GetCitiesLookupSpecification : Specification<CityReadModel>, ISpecification<CityReadModel>
{
    public GetCitiesLookupSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        AsNoTracking = true;
        IsSplitQuery = true;
    }
}
