using PropertyRenting.Domain.ValueObjects.Employee;

namespace PropertyRenting.Application.Commands.Employee.Handlers;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ErrorOr<bool>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<bool>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var id = EntityId.Create(request.EmployeeId);
        var name = EmployeeName.Create(request.Name);
        var mobileNumber = MobileNumber.Create(request.MobileNumber);

        var inInvalid = ValidatorBuilder.Init().Append(id).Append(name).Append(mobileNumber).IsInValid(out List<Error> ErrorList);
        if (inInvalid) return ErrorList;


        var employee = await _employeeRepository.GetEntityByIdAsync(id.Value, cancellationToken);
        if (employee is null) return Domain.Errors.Errors.Common.NotFoundEntity;

        employee.Update(name.Value, mobileNumber.Value);

        _employeeRepository.Update(employee);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
