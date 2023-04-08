namespace PropertyRenting.Application.Commands.Renter;

public record UpdateRenterCommand(Guid RenterId, bool IsActive, int RenterType, string Name, Guid NationalityId, int IdentityType, string IdentityNumber,
     string IdentityIssuePlace, DateOnly BirthDate, DateOnly IdentityExpiryDate, Guid CityId, string RegionCode,
     string PostalCode, string Email, string PhoneNumber, string OtherPhoneNumber, string MobileNumber, string OtherMobileNumber,
     string Fax, string GuarantorName, string GuarantorMobileNumber, string GuarantorAddress, int Gender, string Notes,
     List<ContactPerson> ContactPeople) : IRequest<ErrorOr<bool>>;
