using PropertyRenting.Domain.Enums;

namespace PropertyRenting.Domain.ValueObjects.Common;

public class MemberIdentity : ValueObject
{
    public IdentityType IdentityType { get; }
    public string IdentityNumber { get; }
    public string IdentityIssuePlace { get; }
    public DateOnly IdentityExpiryDate { get; }

    private MemberIdentity(IdentityType identityType, string identityNumber, string identityIssuePlace, DateOnly identityExpiryDate)
    {
        this.IdentityType = identityType;
        this.IdentityNumber = identityNumber;
        this.IdentityIssuePlace = identityIssuePlace;
        this.IdentityExpiryDate = identityExpiryDate;
    }

    public static ErrorOr<MemberIdentity> Create(int identityType, string identityNumber, string identityIssuePlace, DateOnly identityExpiryDate)
    {
        var identityTypeValue = IdentityType.FromValue(identityType);
        if (identityTypeValue is null)
            return Errors.Errors.Common.InvalidIdentityType;

        if (string.IsNullOrWhiteSpace(identityNumber))
            return Errors.Errors.Common.InvalidIdentityNumber;

        if (string.IsNullOrWhiteSpace(identityIssuePlace))
            return Errors.Errors.Common.InvalidIdentityIssuePlace;

        var currentDate = DateTime.Now;
        if (identityExpiryDate < new DateOnly(currentDate.Year, currentDate.Month, currentDate.Day))
            return Errors.Errors.Common.InvalidIdentityExpiryDate;

        return new MemberIdentity(identityTypeValue, identityNumber, identityIssuePlace, identityExpiryDate);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return IdentityType;
        yield return IdentityNumber;
        yield return IdentityIssuePlace;
        yield return IdentityExpiryDate;
    }
}
