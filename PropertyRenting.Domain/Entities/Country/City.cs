using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Domain.ValueObjects.Country;

namespace PropertyRenting.Domain.Entities.Country;

public class City : Entity
{
    private readonly List<District> _districts = new();
    private City()
    {

    }
    private City(EntityId id, CityName name) : base(id)
    {
        Name = name;
    }
    public CityName Name { get; private set; }
    public IReadOnlyCollection<District> Districts => _districts.AsReadOnly();
    internal static City Create(CityName name)
    {
        return new City(EntityId.Create(Guid.NewGuid()).Value, name);
    }
    internal void Update(CityName name)
    {
        Name = name;
    }

    internal void AddDistrict(DistrictName name)
    {
        var district = District.Create(name);
        _districts.Add(district);
    }
    internal ErrorOr<bool> UpdateDistrict(EntityId districtId, DistrictName name)
    {
        var district = _districts.FirstOrDefault(x => x.Id == districtId);
        if (district is null)
            return Errors.Errors.Common.NotFoundEntity;
        district.Update(name);
        return true;
    }
    internal ErrorOr<bool> RemoveDistrict(EntityId districtId)
    {
        var district = _districts.FirstOrDefault(x => x.Id == districtId);
        if (district is null)
            return Errors.Errors.Common.NotFoundEntity;
        _districts.Remove(district);
        return true;
    }
}
