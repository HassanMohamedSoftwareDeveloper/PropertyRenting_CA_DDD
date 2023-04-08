namespace PropertyRenting.Application.DTOs;

public record RenterDTO(Guid Id, bool IsActive, int RenterType, string Name, Guid NationalityId, int IdentityType, string IdentityNumber, string IdentityIssuePlace, DateOnly BirthDate,
    DateOnly IdentityExpiryDate, Guid CityId, Guid CountryId, string RegionCode, string PostalCode, string Email, string PhoneNumber, string OtherPhoneNumber, string MobileNumber,
    string OtherMobileNumber, string Fax, string GuarantorName, string GuarantorMobileNumber, string GuarantorAddress, int Gender, string Notes, List<ContactPersonDTO> ContactPeople);
public record ContactPersonDTO(Guid Id, string Name, string PhoneNumber, string MobileNumber, string Email, int IdentityType, string IdentityNumber, string IdentityIssuePlace, DateOnly? BirthDate,
    DateOnly IdentityExpiryDate, string Notes);

public record RenterReadDTO(Guid Id, bool IsActive, string RenterType, string Name, string Nationality, string IdentityType, string IdentityNumber, DateOnly BirthDate, string City, string Country,
    string RegionCode, string PostalCode, string Email, string PhoneNumber, string MobileNumber, string Gender, string Notes);
