using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Employee;

internal sealed class GetEmployeesByPageWithSearchSpecification : Specification<EmployeeReadModel>, ISpecification<EmployeeReadModel>
{
    public GetEmployeesByPageWithSearchSpecification(string Search)
        : base(x => EF.Functions.Like(x.Name, $"%{Search}%") || EF.Functions.Like(x.MobileNumber, $"%{Search}%"))
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}
