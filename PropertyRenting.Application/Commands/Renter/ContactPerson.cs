namespace PropertyRenting.Application.Commands.Renter;

public record ContactPerson(Guid? Id, string Name, string PhoneNumber, string MobileNumber, string Email, int IdentityType, string IdentityNumber, string IdentityIssuePlace, DateOnly? BirthDate,
    DateOnly IdentityExpiryDate, string Notes);

