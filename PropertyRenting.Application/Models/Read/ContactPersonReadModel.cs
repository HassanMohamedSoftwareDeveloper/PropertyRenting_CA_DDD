namespace PropertyRenting.Application.Models.Read;

public class ContactPersonReadModel : BaseReadModel
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public IdentityType IdentityType { get; set; }
    public string IdentityNumber { get; set; }
    public string IdentityIssuePlace { get; set; }
    public DateOnly IdentityExpiryDate { get; set; }
    public DateOnly? BirthDate { get; set; }
    public Guid RenterId { get; set; }
    public string Notes { get; set; }

    public RenterReadModel Renter { get; set; }
}
