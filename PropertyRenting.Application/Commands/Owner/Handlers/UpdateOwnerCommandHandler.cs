using PropertyRenting.Domain.ValueObjects.Owner;

namespace PropertyRenting.Application.Commands.Owner.Handlers;

public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand, ErrorOr<bool>>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOwnerCommandHandler(IOwnerRepository ownerRepository, IUnitOfWork unitOfWork)
    {
        _ownerRepository = ownerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<bool>> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
    {
        var id = EntityId.Create(request.OwnerId);
        var name = OwnerName.Create(request.Name);
        var mobileNumber = MobileNumber.Create(request.MobileNumber);
        var email = EmailAddress.Create(request.Email);

        var inInvalid = ValidatorBuilder.Init().Append(id).Append(name).Append(mobileNumber).Append(email).IsInValid(out List<Error> ErrorList);
        if (inInvalid) return ErrorList;

        var owner = await _ownerRepository.GetEntityByIdAsync(id.Value, cancellationToken);
        if (owner is null) return Domain.Errors.Errors.Common.NotFoundEntity;

        owner.Update(name.Value, email.Value, mobileNumber.Value);

        _ownerRepository.Update(owner);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
