namespace PropertyRenting.Domain.Enums;

public class RenterType : Enumeration<RenterType>
{
    public static readonly RenterType Person = new(1, "Person");
    public static readonly RenterType Company = new(2, "Company");

    private RenterType(int value, string name) : base(value, name)
    {
    }
}
