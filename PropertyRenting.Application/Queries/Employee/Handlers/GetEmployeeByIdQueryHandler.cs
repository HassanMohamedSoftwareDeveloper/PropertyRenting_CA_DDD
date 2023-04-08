using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Employee;

namespace PropertyRenting.Application.Queries.Employee.Handlers;

internal sealed class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, ErrorOr<EmployeeDTO>>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;

    public GetEmployeeByIdQueryHandler(IEmployeeReadRepository employeeReadRepository)
    {
        _employeeReadRepository = employeeReadRepository;
    }
    public async Task<ErrorOr<EmployeeDTO>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _employeeReadRepository.GetByIdAsync<EmployeeDTO>(new GetEmployeeByIdSpecification(request.EmployeeId), cancellationToken);
        if (data is null) return Errors.Queries.NotFound;
        return data;
    }
}
