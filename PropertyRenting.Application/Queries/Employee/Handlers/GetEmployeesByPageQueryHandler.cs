using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Employee;

namespace PropertyRenting.Application.Queries.Employee.Handlers;

internal sealed class GetEmployeesByPageQueryHandler : IRequestHandler<GetEmployeesByPageQuery, ErrorOr<PagedList<EmployeeDTO>>>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;

    public GetEmployeesByPageQueryHandler(IEmployeeReadRepository employeeReadRepository)
    {
        _employeeReadRepository = employeeReadRepository;
    }
    public async Task<ErrorOr<PagedList<EmployeeDTO>>> Handle(GetEmployeesByPageQuery request, CancellationToken cancellationToken)
    {
        var data = await _employeeReadRepository.GetPageAsync<EmployeeDTO>(new GetEmployeesByPageSpecification(),
            request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
