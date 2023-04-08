using PropertyRenting.Domain.ValueObjects.Contributer;

namespace PropertyRenting.Application.Commands.Contributer.Handlers;

public class UpdateContributerCommandHandler : IRequestHandler<UpdateContributerCommand, ErrorOr<bool>>
{
    private readonly IContributerRepository _contributerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContributerCommandHandler(IContributerRepository contributerRepository, IUnitOfWork unitOfWork)
    {
        _contributerRepository = contributerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<bool>> Handle(UpdateContributerCommand request, CancellationToken cancellationToken)
    {
        var id = EntityId.Create(request.ContributerId);
        var name = ContributerName.Create(request.Name);
        var mobileNumber = MobileNumber.Create(request.MobileNumber);
        var email = EmailAddress.Create(request.Email);

        var inInvalid = ValidatorBuilder.Init().Append(id).Append(name).Append(mobileNumber).Append(email).IsInValid(out List<Error> ErrorList);
        if (inInvalid) return ErrorList;

        var contributer = await _contributerRepository.GetEntityByIdAsync(id.Value, cancellationToken);
        if (contributer is null) return Domain.Errors.Errors.Common.NotFoundEntity;

        contributer.Update(name.Value, email.Value, mobileNumber.Value);

        _contributerRepository.Update(contributer);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
