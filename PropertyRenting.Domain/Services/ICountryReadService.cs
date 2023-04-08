using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Domain.ValueObjects.Country;

namespace PropertyRenting.Domain.Services;

public interface ICountryReadService
{
    Task<bool> ExistsByNameOrNationaalityAsync(EntityId countryId, CountryName name, Nationality nationality);
    Task<bool> CanDeleteAsync(EntityId countryId);
    Task<bool> CanDeleteCityAsync(EntityId cityId);
    Task<bool> CanDeleteDistrictAsync(EntityId districtId);
}
