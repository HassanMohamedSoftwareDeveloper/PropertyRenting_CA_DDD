using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Domain.ValueObjects.Contributer;

namespace PropertyRenting.Domain.Aggregates;

public class Contributer : AggregateRoot
{
    private Contributer()
    {

    }
    private Contributer(EntityId id, ContributerName name, EmailAddress email, MobileNumber mobileNumber) : base(id)
    {
        this.Name = name;
        this.Email = email;
        this.MobileNumber = mobileNumber;
    }
    public ContributerName Name { get; private set; }
    public MobileNumber MobileNumber { get; private set; }
    public EmailAddress Email { get; private set; }

    public static Contributer Create(ContributerName name, EmailAddress email, MobileNumber mobileNumber)
    {
        return new Contributer(EntityId.Create(Guid.NewGuid()).Value, name, email, mobileNumber);
    }
    public void Update(ContributerName name, EmailAddress email, MobileNumber mobileNumber)
    {
        this.Name = name;
        this.Email = email;
        this.MobileNumber = mobileNumber;
    }
}
