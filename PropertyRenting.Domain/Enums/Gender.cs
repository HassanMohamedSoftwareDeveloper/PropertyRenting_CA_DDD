namespace PropertyRenting.Domain.Enums;

public class Gender : Enumeration<Gender>
{
    public static readonly Gender Male = new(1, "Male");
    public static readonly Gender Female = new(2, "Female");

    private Gender(int value, string name) : base(value, name)
    {
    }
}
