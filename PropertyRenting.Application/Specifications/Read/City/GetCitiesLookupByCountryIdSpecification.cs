using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.City;

internal sealed class GetCitiesLookupByCountryIdSpecification : Specification<CityReadModel>, ISpecification<CityReadModel>
{
    public GetCitiesLookupByCountryIdSpecification(Guid CountryId) : base(x => x.CountryId == CountryId)
    {
        AddOrderBy(x => x.CreatedAt);
        AsNoTracking = true;
        IsSplitQuery = true;
    }
}
