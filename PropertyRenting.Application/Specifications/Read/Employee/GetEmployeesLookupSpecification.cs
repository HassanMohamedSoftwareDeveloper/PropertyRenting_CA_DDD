using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Employee;

internal sealed class GetEmployeesLookupSpecification : Specification<EmployeeReadModel>, ISpecification<EmployeeReadModel>
{
    public GetEmployeesLookupSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
