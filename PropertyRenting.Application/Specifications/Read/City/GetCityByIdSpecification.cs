using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.City;

internal sealed class GetCityByIdSpecification : Specification<CityReadModel>, ISpecification<CityReadModel>
{
    public GetCityByIdSpecification(Guid Id) : base(x => x.Id == Id)
    {
        AsNoTracking = true;
        IsSplitQuery = true;
    }
}
