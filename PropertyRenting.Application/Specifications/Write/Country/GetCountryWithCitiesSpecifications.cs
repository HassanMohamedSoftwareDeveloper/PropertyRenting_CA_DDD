using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Write.Country;

internal sealed class GetCountryWithCitiesSpecifications : Specification<Domain.Aggregates.Country>, ISpecification<Domain.Aggregates.Country>
{
    public GetCountryWithCitiesSpecifications(EntityId countryId)
        : base(x => x.Id == countryId)
    {
        AddInclude(x => x.Cities);
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
    }
}
