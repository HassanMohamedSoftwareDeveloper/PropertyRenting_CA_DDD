using PropertyRenting.Domain.Entities.Country;
using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Domain.ValueObjects.Country;

namespace PropertyRenting.Domain.Aggregates;

public class Country : AggregateRoot
{
    #region Fields :
    private readonly List<City> _cities = new();
    #endregion

    #region CTORS :
    private Country()
    {

    }
    private Country(EntityId id, CountryName name, Nationality nationality) : base(id)
    {
        Name = name;
        Nationality = nationality;
    }
    #endregion

    #region PROPS :
    public CountryName Name { get; private set; }
    public Nationality Nationality { get; private set; }
    public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();
    #endregion

    #region Methods :
    public static async Task<ErrorOr<Country>> Create(CountryName name, Nationality nationality, ICountryReadService countryReadService)
    {
        bool isExisted = await countryReadService.ExistsByNameOrNationaalityAsync(null, name, nationality);
        if (isExisted)
            return Errors.Errors.Country.ExistCountry;

        return new Country(EntityId.Create(Guid.NewGuid()).Value, name, nationality);
    }
    public async Task<ErrorOr<bool>> Update(CountryName name, Nationality nationality, ICountryReadService countryReadService)
    {
        bool isExisted = await countryReadService.ExistsByNameOrNationaalityAsync(this.Id, name, nationality);
        if (isExisted)
            return Errors.Errors.Country.ExistCountry;

        this.Name = name;
        this.Nationality = nationality;

        return true;
    }

    public void AddCity(CityName cityName)
    {
        var city = City.Create(cityName);
        _cities.Add(city);
    }
    public ErrorOr<bool> UpdateCity(EntityId cityId, CityName name)
    {
        var city = _cities.FirstOrDefault(x => x.Id == cityId);
        if (city is null)
            return Errors.Errors.Common.NotFoundEntity;
        city.Update(name);
        return true;
    }
    public async Task<ErrorOr<bool>> RemoveCity(EntityId cityId, ICountryReadService countryReadService)
    {
        var city = _cities.FirstOrDefault(x => x.Id == cityId);
        if (city is null)
            return Errors.Errors.Common.NotFoundEntity;

        var canDelete = await countryReadService.CanDeleteCityAsync(cityId);
        if (canDelete is false)
            return Errors.Errors.Common.HasTransactions;

        _cities.Remove(city);
        return true;
    }

    public ErrorOr<bool> AddDistrict(EntityId cityId, DistrictName name)
    {
        var city = _cities.FirstOrDefault(x => x.Id == cityId);
        if (city is null)
            return Errors.Errors.Common.NotFoundEntity;
        city.AddDistrict(name);
        return true;
    }
    public ErrorOr<bool> UpdateDistrict(EntityId cityId, EntityId districtId, DistrictName name)
    {
        var city = _cities.FirstOrDefault(x => x.Id == cityId);
        if (city is null)
            return Errors.Errors.Common.NotFoundEntity;
        city.UpdateDistrict(districtId, name);
        return true;
    }
    public async Task<ErrorOr<bool>> RemoveDistrict(EntityId cityId, EntityId districtId, ICountryReadService countryReadService)
    {
        var city = _cities.FirstOrDefault(x => x.Id == cityId);
        if (city is null)
            return Errors.Errors.Common.NotFoundEntity;

        var canDelete = await countryReadService.CanDeleteDistrictAsync(districtId);
        if (canDelete is false)
            return Errors.Errors.Common.HasTransactions;

        city.RemoveDistrict(districtId);
        return true;
    }
    #endregion
}