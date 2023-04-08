using PropertyRenting.Domain.Entities.Renter;
using PropertyRenting.Domain.Enums;
using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Domain.ValueObjects.Renter;

namespace PropertyRenting.Domain.Aggregates;

public class Renter : AggregateRoot
{
    #region Fields :
    private readonly List<ContactPerson> _contactPeople = new();
    #endregion

    #region CTORS :
    private Renter()
    {

    }
    private Renter(EntityId id,
                   bool isActive,
                   RenterType renterType,
                   RenterName name,
                   EntityId nationalityId,
                   MemberIdentity identity,
                   DateOnly birthDate,
                   EntityId cityId,
                   string regionCode,
                   string postalCode,
                   EmailAddress email,
                   PhoneNumber phoneNumber,
                   PhoneNumber otherPhoneNumber,
                   MobileNumber mobileNumber,
                   MobileNumber otherMobileNumber,
                   string fax,
                   string guarantorName,
                   MobileNumber guarantorMobileNumber,
                   string guarantorAddress,
                   Gender gender,
                   string notes) : base(id)
    {
        IsActive = isActive;
        RenterType = renterType;
        Name = name;
        NationalityId = nationalityId;
        Identity = identity;
        BirthDate = birthDate;
        CityId = cityId;
        RegionCode = regionCode;
        PostalCode = postalCode;
        Email = email;
        PhoneNumber = phoneNumber;
        OtherPhoneNumber = otherPhoneNumber;
        MobileNumber = mobileNumber;
        OtherMobileNumber = otherMobileNumber;
        Fax = fax;
        GuarantorName = guarantorName;
        GuarantorMobileNumber = guarantorMobileNumber;
        GuarantorAddress = guarantorAddress;
        Gender = gender;
        Notes = notes;
    }
    #endregion

    #region PROPS :
    public bool IsActive { get; private set; }
    public RenterType RenterType { get; private set; }
    public RenterName Name { get; private set; }
    public EntityId NationalityId { get; private set; }
    public MemberIdentity Identity { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public EntityId CityId { get; private set; }
    public string RegionCode { get; private set; }
    public string PostalCode { get; private set; }
    public EmailAddress Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public PhoneNumber OtherPhoneNumber { get; private set; }
    public MobileNumber MobileNumber { get; private set; }
    public MobileNumber OtherMobileNumber { get; private set; }
    public string Fax { get; private set; }
    public string GuarantorName { get; private set; }
    public MobileNumber GuarantorMobileNumber { get; private set; }
    public string GuarantorAddress { get; private set; }
    public Gender Gender { get; private set; }
    public bool IsBlackListed { get; private set; }
    public string Notes { get; private set; }
    public IReadOnlyCollection<ContactPerson> ContactPeople => _contactPeople.AsReadOnly();
    #endregion

    #region Methods :
    public static Renter Create(bool isActive,
                                RenterType renterType,
                                RenterName name,
                                EntityId nationalityId,
                                MemberIdentity identity,
                                DateOnly birthDate,
                                EntityId cityId,
                                string regionCode,
                                string postalCode,
                                EmailAddress email,
                                PhoneNumber phoneNumber,
                                PhoneNumber otherPhoneNumber,
                                MobileNumber mobileNumber,
                                MobileNumber otherMobileNumber,
                                string fax,
                                string guarantorName,
                                MobileNumber guarantorMobileNumber,
                                string guarantorAddress,
                                Gender gender,
                                string notes)
    {
        return new Renter(EntityId.Create(Guid.NewGuid()).Value, isActive, renterType, name, nationalityId, identity, birthDate, cityId,
            regionCode, postalCode, email, phoneNumber, otherPhoneNumber, mobileNumber, otherMobileNumber, fax, guarantorName, guarantorMobileNumber, guarantorAddress,
            gender, notes);
    }
    public Renter Update(bool isActive,
                         RenterType renterType,
                         RenterName name,
                         EntityId nationalityId,
                         MemberIdentity identity,
                         DateOnly birthDate,
                         EntityId cityId,
                         string regionCode,
                         string postalCode,
                         EmailAddress email,
                         PhoneNumber phoneNumber,
                         PhoneNumber otherPhoneNumber,
                         MobileNumber mobileNumber,
                         MobileNumber otherMobileNumber,
                         string fax,
                         string guarantorName,
                         MobileNumber guarantorMobileNumber,
                         string guarantorAddress,
                         Gender gender,
                         string notes)
    {
        IsActive = isActive;
        RenterType = renterType;
        Name = name;
        NationalityId = nationalityId;
        Identity = identity;
        BirthDate = birthDate;
        CityId = cityId;
        RegionCode = regionCode;
        PostalCode = postalCode;
        Email = email;
        PhoneNumber = phoneNumber;
        OtherPhoneNumber = otherPhoneNumber;
        MobileNumber = mobileNumber;
        OtherMobileNumber = otherMobileNumber;
        Fax = fax;
        GuarantorName = guarantorName;
        GuarantorMobileNumber = guarantorMobileNumber;
        GuarantorAddress = guarantorAddress;
        Gender = gender;
        Notes = notes;

        return this;
    }

    public void AddContactPerson(ContactPersonName name,
                                 PhoneNumber phoneNumber,
                                 MobileNumber mobileNumber,
                                 EmailAddress email,
                                 MemberIdentity identity,
                                 DateOnly? birthDate,
                                 string notes)
    {
        var contactPerson = ContactPerson.Create(name, phoneNumber, mobileNumber, email, identity, birthDate, notes);
        _contactPeople.Add(contactPerson);
    }
    public ErrorOr<bool> UpdateContactPerson(EntityId contactPersonId,
                                             ContactPersonName name,
                                             PhoneNumber phoneNumber,
                                             MobileNumber mobileNumber,
                                             EmailAddress email,
                                             MemberIdentity identity,
                                             DateOnly? birthDate,
                                             string notes)
    {
        var contactPerson = ContactPeople.SingleOrDefault(x => x.Id == contactPersonId);
        if (contactPerson is null)
            return Errors.Errors.Common.NotFoundEntity;

        contactPerson.Update(name, phoneNumber, mobileNumber, email, identity, birthDate, notes);

        return true;
    }
    public void DeleteContactPeople(List<ContactPerson> contactPeople)
    {
        foreach (var contactPerson in contactPeople)
        {
            _contactPeople.Remove(contactPerson);
        }
    }
    #endregion
}
