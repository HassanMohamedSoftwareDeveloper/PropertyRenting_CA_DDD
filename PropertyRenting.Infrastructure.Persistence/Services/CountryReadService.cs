using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Services;
using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Domain.ValueObjects.Country;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Services;

internal sealed class CountryReadService : BaseReadSevice, ICountryReadService
{
    public CountryReadService(PropertyRentingReadContext context) : base(context)
    {
    }

    public async Task<bool> CanDeleteAsync(EntityId countryId)
    {
        return true;
    }

    public async Task<bool> CanDeleteCityAsync(EntityId cityId)
    {
        return true;
    }

    public async Task<bool> CanDeleteDistrictAsync(EntityId districtId)
    {
        return true;
    }

    public async Task<bool> ExistsByNameOrNationaalityAsync(EntityId countryId, CountryName name, Nationality nationality)
    {
        return await Context.Set<CountryReadModel>()
         .AnyAsync(x => (countryId == null || x.Id != countryId.Value)
         && (EF.Functions.Like(x.Name, name.Value) || (EF.Functions.Like(x.Nationality, nationality.Value))));
    }

}
