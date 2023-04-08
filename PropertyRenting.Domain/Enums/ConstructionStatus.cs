namespace PropertyRenting.Domain.Enums;

public class ConstructionStatus : Enumeration<ConstructionStatus>
{
    public static readonly ConstructionStatus New = new(1, "New");
    public static readonly ConstructionStatus Middle = new(2, "Middle");
    public static readonly ConstructionStatus Housing = new(3, "Old");

    private ConstructionStatus(int value, string name) : base(value, name)
    {
    }
}
