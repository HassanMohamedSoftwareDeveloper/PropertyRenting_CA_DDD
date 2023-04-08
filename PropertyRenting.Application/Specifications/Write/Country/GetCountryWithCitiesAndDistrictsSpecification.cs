using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Write.Country;

internal sealed class GetCountryWithCitiesAndDistrictsSpecification : Specification<Domain.Aggregates.Country>, ISpecification<Domain.Aggregates.Country>
{
    public GetCountryWithCitiesAndDistrictsSpecification(EntityId countryId, EntityId cityId)
        : base(x => x.Id == countryId)
    {
        AddInclude(x => x.Cities.Where(x => x.Id == cityId).Select(c => c.Districts));
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
    }
}
