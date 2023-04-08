using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Employee;

namespace PropertyRenting.Application.Queries.Employee.Handlers;

internal sealed class GetEmployeesLookupQueryHandler : IRequestHandler<GetEmployeesLookupQuery, ErrorOr<List<BaseLookupDTO>>>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;

    public GetEmployeesLookupQueryHandler(IEmployeeReadRepository employeeReadRepository)
    {
        _employeeReadRepository = employeeReadRepository;
    }
    public async Task<ErrorOr<List<BaseLookupDTO>>> Handle(GetEmployeesLookupQuery request, CancellationToken cancellationToken)
    {
        var data = await _employeeReadRepository.GetLookupAsync<BaseLookupDTO>(new GetEmployeesLookupSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}
