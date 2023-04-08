namespace PropertyRenting.Application.Commands.Owner.Handlers;

public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand, ErrorOr<bool>>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOwnerCommandHandler(IOwnerRepository ownerRepository, IUnitOfWork unitOfWork)
    {
        _ownerRepository = ownerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<bool>> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
    {
        var id = EntityId.Create(request.OwnerId);
        if (id.IsError) return id.FirstError;


        var owner = await _ownerRepository.GetEntityByIdAsync(id.Value, cancellationToken);
        if (owner is null) return Domain.Errors.Errors.Common.NotFoundEntity;

        _ownerRepository.Delete(owner);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
