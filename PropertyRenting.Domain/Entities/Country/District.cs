using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Domain.ValueObjects.Country;

namespace PropertyRenting.Domain.Entities.Country;

public class District : Entity
{
    private District()
    {

    }
    private District(EntityId id, DistrictName name) : base(id)
    {
        Name = name;
    }
    public DistrictName Name { get; private set; }

    internal static District Create(DistrictName name)
    {
        return new District(EntityId.Create(Guid.NewGuid()).Value, name);
    }
    internal void Update(DistrictName name)
    {
        Name = name;
    }
}
