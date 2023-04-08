namespace PropertyRenting.Application.Models.Read;

public class RenterReadModel : BaseReadModel
{
    public bool IsActive { get; set; }
    public RenterType RenterType { get; set; }
    public string Name { get; set; }
    public Guid NationalityId { get; set; }
    public IdentityType IdentityType { get; set; }
    public string IdentityNumber { get; set; }
    public string IdentityIssuePlace { get; set; }
    public DateOnly IdentityExpiryDate { get; set; }
    public DateOnly BirthDate { get; set; }
    public Guid CityId { get; set; }
    public string RegionCode { get; set; }
    public string PostalCode { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string OtherPhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string OtherMobileNumber { get; set; }
    public string Fax { get; set; }
    public string GuarantorName { get; set; }
    public string GuarantorMobileNumber { get; set; }
    public string GuarantorAddress { get; set; }
    public Gender Gender { get; set; }
    public bool IsBlackListed { get; set; }
    public string Notes { get; set; }

    public CityReadModel City { get; set; }
    public CountryReadModel Nationality { get; set; }

    public IReadOnlyCollection<ContactPersonReadModel> ContactPeople { get; set; }
}
