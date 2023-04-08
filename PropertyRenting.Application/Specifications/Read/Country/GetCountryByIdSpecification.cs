using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Country;

internal sealed class GetCountryByIdSpecification : Specification<CountryReadModel>, ISpecification<CountryReadModel>
{
    public GetCountryByIdSpecification(Guid Id) : base(x => x.Id == Id)
    {
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
