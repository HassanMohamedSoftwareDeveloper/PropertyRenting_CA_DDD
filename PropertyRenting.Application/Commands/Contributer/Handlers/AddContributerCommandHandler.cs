using PropertyRenting.Application.Commands.Contributer;
using PropertyRenting.Application.Helpers;
using PropertyRenting.Application.Primitives;
using PropertyRenting.Domain.ValueObjects.Contributer;

namespace PropertyRenting.Application.Commands.Contributer.Handlers;

public class AddContributerCommandHandler : IRequestHandler<AddContributerCommand, ErrorOr<bool>>
{
    private readonly IContributerRepository _contributerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddContributerCommandHandler(IContributerRepository contributerRepository, IUnitOfWork unitOfWork)
    {
        _contributerRepository = contributerRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<bool>> Handle(AddContributerCommand request, CancellationToken cancellationToken)
    {
        var name = ContributerName.Create(request.Name);
        var mobileNumber = MobileNumber.Create(request.MobileNumber);
        var email = EmailAddress.Create(request.Email);

        var inInvalid = ValidatorBuilder.Init().Append(name).Append(mobileNumber).Append(email).IsInValid(out List<Error> ErrorList);
        if (inInvalid) return ErrorList;

        var contributer = Domain.Aggregates.Contributer.Create(name.Value, email.Value, mobileNumber.Value);

        _contributerRepository.Create(contributer);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
