using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Employee;

namespace PropertyRenting.Application.Queries.Employee.Handlers;

internal sealed class GetEmployeesByPageWithSearchQueryHandler : IRequestHandler<GetEmployeesByPageWithSearchQuery, ErrorOr<PagedList<EmployeeDTO>>>
{
    private readonly IEmployeeReadRepository _employeeReadRepository;

    public GetEmployeesByPageWithSearchQueryHandler(IEmployeeReadRepository employeeReadRepository)
    {
        _employeeReadRepository = employeeReadRepository;
    }
    public async Task<ErrorOr<PagedList<EmployeeDTO>>> Handle(GetEmployeesByPageWithSearchQuery request, CancellationToken cancellationToken)
    {
        var data = await _employeeReadRepository.GetPageAsync<EmployeeDTO>(new GetEmployeesByPageWithSearchSpecification(request.SearchValue),
          request.PageNumber, request.PageSize, cancellationToken);
        return data;
    }
}
