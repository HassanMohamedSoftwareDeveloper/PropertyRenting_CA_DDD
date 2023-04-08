using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Employee;

internal sealed class GetEmployeeByIdSpecification : Specification<EmployeeReadModel>, ISpecification<EmployeeReadModel>
{
    public GetEmployeeByIdSpecification(Guid Id) : base(x => x.Id == Id)
    {
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
