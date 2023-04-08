using PropertyRenting.Application.DTOs;

namespace PropertyRenting.Application.Queries.Employee;

public record GetAllEmployeesQuery() : IRequest<ErrorOr<List<EmployeeDTO>>>;
public record GetEmployeesLookupQuery() : IRequest<ErrorOr<List<BaseLookupDTO>>>;
public record GetEmployeeByIdQuery(Guid EmployeeId) : IRequest<ErrorOr<EmployeeDTO>>;
public record GetEmployeesByPageQuery(int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<EmployeeDTO>>>;
public record GetEmployeesByPageWithSearchQuery(string SearchValue, int PageNumber, int PageSize) : IRequest<ErrorOr<PagedList<EmployeeDTO>>>;