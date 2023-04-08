namespace PropertyRenting.Application.Commands.Employee;

public record UpdateEmployeeCommand(Guid EmployeeId, string Name, string MobileNumber) : IRequest<ErrorOr<bool>>;
