namespace PropertyRenting.Domain.Enums;

public class BuildingType : Enumeration<BuildingType>
{
    public static readonly BuildingType Building = new(1, "Building");
    public static readonly BuildingType Mall = new(2, "Mall");
    public static readonly BuildingType Housing = new(3, "Housing");
    public static readonly BuildingType Managerial = new(4, "Managerial");

    private BuildingType(int value, string name) : base(value, name)
    {
    }
}
