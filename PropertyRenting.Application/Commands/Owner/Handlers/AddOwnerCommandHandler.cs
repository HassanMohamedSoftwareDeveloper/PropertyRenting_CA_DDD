using PropertyRenting.Domain.ValueObjects.Owner;

namespace PropertyRenting.Application.Commands.Owner.Handlers;

public class AddOwnerCommandHandler : IRequestHandler<AddOwnerCommand, ErrorOr<bool>>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddOwnerCommandHandler(IOwnerRepository ownerRepository, IUnitOfWork unitOfWork)
    {
        _ownerRepository = ownerRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<bool>> Handle(AddOwnerCommand request, CancellationToken cancellationToken)
    {
        var name = OwnerName.Create(request.Name);
        var mobileNumber = MobileNumber.Create(request.MobileNumber);
        var email = EmailAddress.Create(request.Email);

        var inInvalid = ValidatorBuilder.Init().Append(name).Append(mobileNumber).Append(email).IsInValid(out List<Error> ErrorList);
        if (inInvalid) return ErrorList;

        var owner = Domain.Aggregates.Owner.Create(name.Value, email.Value, mobileNumber.Value);

        _ownerRepository.Create(owner);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
