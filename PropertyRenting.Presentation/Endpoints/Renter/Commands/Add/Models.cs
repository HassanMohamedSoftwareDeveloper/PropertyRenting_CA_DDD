namespace PropertyRenting.API.Endpoints.Renter.Commands.Add;

internal record Request
{
    public bool IsActive { get; set; }
    public int RenterType { get; set; }
    public string Name { get; set; }
    public Guid NationalityId { get; set; }
    public int IdentityType { get; }
    public string IdentityNumber { get; }
    public string IdentityIssuePlace { get; }
    public DateOnly IdentityExpiryDate { get; }
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
    public int Gender { get; set; }
    public bool IsBlackListed { get; set; }
    public string Notes { get; set; }
    public List<ContactPerson> ContactPeople { get; set; }
}
internal record ContactPerson
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public int IdentityType { get; }
    public string IdentityNumber { get; }
    public string IdentityIssuePlace { get; }
    public DateOnly IdentityExpiryDate { get; }
    public DateOnly? BirthDate { get; set; }
    public string Notes { get; set; }
}
internal class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}