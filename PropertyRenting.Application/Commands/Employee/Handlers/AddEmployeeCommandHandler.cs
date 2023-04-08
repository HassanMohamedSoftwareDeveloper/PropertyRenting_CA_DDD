using PropertyRenting.Domain.ValueObjects.Employee;

namespace PropertyRenting.Application.Commands.Employee.Handlers;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, ErrorOr<bool>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<bool>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var name = EmployeeName.Create(request.Name);
        var mobileNumber = MobileNumber.Create(request.MobileNumber);

        var inInvalid = ValidatorBuilder.Init().Append(name).Append(mobileNumber).IsInValid(out List<Error> ErrorList);
        if (inInvalid) return ErrorList;

        var owner = Domain.Aggregates.Employee.Create(name.Value, mobileNumber.Value);

        _employeeRepository.Create(owner);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}