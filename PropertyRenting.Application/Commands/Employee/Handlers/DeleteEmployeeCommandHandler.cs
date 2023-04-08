namespace PropertyRenting.Application.Commands.Employee.Handlers;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ErrorOr<bool>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<bool>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var id = EntityId.Create(request.EmployeeId);
        if (id.IsError) return id.FirstError;


        var employee = await _employeeRepository.GetEntityByIdAsync(id.Value, cancellationToken);
        if (employee is null) return Domain.Errors.Errors.Common.NotFoundEntity;

        _employeeRepository.Delete(employee);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
