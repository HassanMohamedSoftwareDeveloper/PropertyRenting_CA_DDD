using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Domain.ValueObjects.Owner;

namespace PropertyRenting.Domain.Aggregates;

public class Owner : AggregateRoot
{
    private Owner()
    {

    }
    private Owner(EntityId id, OwnerName name, EmailAddress email, MobileNumber mobileNumber) : base(id)
    {
        this.Name = name;
        this.Email = email;
        this.MobileNumber = mobileNumber;
    }
    public OwnerName Name { get; private set; }
    public MobileNumber MobileNumber { get; private set; }
    public EmailAddress Email { get; private set; }

    public static Owner Create(OwnerName name, EmailAddress email, MobileNumber mobileNumber)
    {
        return new Owner(EntityId.Create(Guid.NewGuid()).Value, name, email, mobileNumber);
    }
    public void Update(OwnerName name, EmailAddress email, MobileNumber mobileNumber)
    {
        this.Name = name;
        this.Email = email;
        this.MobileNumber = mobileNumber;
    }
}
