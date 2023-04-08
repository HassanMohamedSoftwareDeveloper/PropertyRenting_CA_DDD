using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Employee;

namespace PropertyRenting.Application.Queries.Employee.Handlers;

internal sealed class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, ErrorOr<List<EmployeeDTO>>>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;

    public GetAllEmployeesQueryHandler(IEmployeeReadRepository employeeReadRepository)
    {
        _employeeReadRepository = employeeReadRepository;
    }
    public async Task<ErrorOr<List<EmployeeDTO>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var data = await _employeeReadRepository.GetAsync<EmployeeDTO>(new GetEmployeesSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
