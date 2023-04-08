namespace PropertyRenting.Application.Commands.Renter.Handlers;

public class DeleteRenterCommandHandler : IRequestHandler<DeleteRenterCommand, ErrorOr<bool>>
{
    private readonly IRenterRepository _renterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRenterReadService _renterReadService;

    public DeleteRenterCommandHandler(IRenterRepository renterRepository, IUnitOfWork unitOfWork, IRenterReadService renterReadService)
    {
        _renterRepository = renterRepository;
        _unitOfWork = unitOfWork;
        _renterReadService = renterReadService;
    }
    public async Task<ErrorOr<bool>> Handle(DeleteRenterCommand request, CancellationToken cancellationToken)
    {
        var renterId = EntityId.Create(request.RenterId);
        if (renterId.IsError)
            return renterId.FirstError;

        var renter = await _renterRepository.GetEntityByIdAsync(renterId.Value, cancellationToken);
        if (renter is null)
            return Domain.Errors.Errors.Common.NotFoundEntity;

        var canDelete = await _renterReadService.CanDeleteAsync(renterId.Value);
        if (canDelete is false)
            return Domain.Errors.Errors.Common.HasTransactions;

        _renterRepository.Delete(renter);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);

    }
}
