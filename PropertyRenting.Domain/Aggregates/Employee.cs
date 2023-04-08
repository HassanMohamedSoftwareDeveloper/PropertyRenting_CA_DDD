using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Domain.ValueObjects.Employee;

namespace PropertyRenting.Domain.Aggregates;

public class Employee : AggregateRoot
{
    private Employee()
    {

    }
    private Employee(EntityId id, EmployeeName name, MobileNumber mobileNumber) : base(id)
    {
        this.Name = name;
        this.MobileNumber = mobileNumber;
    }
    public EmployeeName Name { get; private set; }
    public MobileNumber MobileNumber { get; private set; }

    public static Employee Create(EmployeeName name, MobileNumber mobileNumber)
    {
        return new Employee(EntityId.Create(Guid.NewGuid()).Value, name, mobileNumber);
    }
    public void Update(EmployeeName name, MobileNumber mobileNumber)
    {
        this.Name = name;
        this.MobileNumber = mobileNumber;
    }
}
