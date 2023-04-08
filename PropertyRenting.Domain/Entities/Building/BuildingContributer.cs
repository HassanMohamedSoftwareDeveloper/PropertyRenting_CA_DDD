using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Domain.Entities.Building;

public class BuildingContributer : Entity
{
    private BuildingContributer()
    {

    }
    private BuildingContributer(EntityId id, EntityId contributerId, Percentage percentage) : base(id)
    {
        ContributerId = contributerId;
        Percentage = percentage;
    }

    public EntityId ContributerId { get; private set; }
    public Percentage Percentage { get; private set; }

    internal static BuildingContributer Create(EntityId contributerId, Percentage percentage)
    {
        return new BuildingContributer(EntityId.Create(Guid.NewGuid()).Value, contributerId, percentage);
    }
}
