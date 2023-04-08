namespace PropertyRenting.Application.Commands.Building.Handlers;

public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand, ErrorOr<bool>>
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBuildingReadService _buildingReadService;

    public DeleteBuildingCommandHandler(IBuildingRepository buildingRepository, IUnitOfWork unitOfWork, IBuildingReadService buildingReadService)
    {
        _buildingRepository = buildingRepository;
        _unitOfWork = unitOfWork;
        _buildingReadService = buildingReadService;
    }

    public async Task<ErrorOr<bool>> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
    {
        var buildingId = EntityId.Create(request.BuildingId);
        if (buildingId.IsError) return buildingId.FirstError;

        var building = await _buildingRepository.GetEntityByIdAsync(buildingId.Value, cancellationToken);
        if (building is null) return Domain.Errors.Errors.Common.NotFoundEntity;

        var canDelete = await _buildingReadService.CanDeleteAsync(buildingId.Value);
        if (canDelete is false) return Domain.Errors.Errors.Common.HasTransactions;

        _buildingRepository.Delete(building);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
