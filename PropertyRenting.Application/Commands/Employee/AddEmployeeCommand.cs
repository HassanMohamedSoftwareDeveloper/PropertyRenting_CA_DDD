namespace PropertyRenting.Application.Commands.Employee;

public record AddEmployeeCommand(string Name, string MobileNumber) : IRequest<ErrorOr<bool>>;
