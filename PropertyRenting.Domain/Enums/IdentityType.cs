namespace PropertyRenting.Domain.Enums;

public class IdentityType : Enumeration<IdentityType>
{
    public static readonly IdentityType NationalNumber = new(1, "NationalNumber");
    public static readonly IdentityType Passport = new(2, "Passport");
    public static readonly IdentityType DrivingLicence = new(3, "DrivingLicence");
    public static readonly IdentityType ResidencePermit = new(4, "ResidencePermit");

    private IdentityType(int value, string name) : base(value, name)
    {
    }
}

