namespace PropertyRenting.Application.Commands.Employee;

public record DeleteEmployeeCommand(Guid EmployeeId) : IRequest<ErrorOr<bool>>;