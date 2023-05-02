namespace PropertyRenting.API.Endpoints.Employee;

internal sealed class EmployeeGroup : Group
{
    public EmployeeGroup()
    {
        Configure("employees", ep => { });
    }
}
