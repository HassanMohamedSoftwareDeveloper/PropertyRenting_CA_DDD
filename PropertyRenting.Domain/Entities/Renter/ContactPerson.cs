using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Domain.ValueObjects.Renter;

namespace PropertyRenting.Domain.Entities.Renter;

public class ContactPerson : Entity
{
    #region CTORS :
    private ContactPerson()
    {

    }
    private ContactPerson(EntityId id,
                          ContactPersonName name,
                          PhoneNumber phoneNumber,
                          MobileNumber mobileNumber,
                          EmailAddress email,
                          MemberIdentity identity,
                          DateOnly? birthDate,
                          string notes) : base(id)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        MobileNumber = mobileNumber;
        Email = email;
        Identity = identity;
        BirthDate = birthDate;
        Notes = notes;
    }

    #endregion

    #region PROPS :
    public ContactPersonName Name { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public MobileNumber MobileNumber { get; private set; }
    public EmailAddress Email { get; private set; }
    public MemberIdentity Identity { get; private set; }
    public DateOnly? BirthDate { get; private set; }
    public string Notes { get; private set; }
    #endregion

    #region Methods :
    internal static ContactPerson Create(ContactPersonName name,
                                         PhoneNumber phoneNumber,
                                         MobileNumber mobileNumber,
                                         EmailAddress email,
                                         MemberIdentity identity,
                                         DateOnly? birthDate,
                                         string notes)
    {
        return new(EntityId.Create(Guid.NewGuid()).Value, name, phoneNumber,
            mobileNumber, email, identity, birthDate, notes); ;
    }
    internal ContactPerson Update(ContactPersonName name,
                                  PhoneNumber phoneNumber,
                                  MobileNumber mobileNumber,
                                  EmailAddress email,
                                  MemberIdentity identity,
                                  DateOnly? birthDate,
                                  string notes)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        MobileNumber = mobileNumber;
        Email = email;
        Identity = identity;
        BirthDate = birthDate;
        Notes = notes;
        return this;
    }
    #endregion
}
