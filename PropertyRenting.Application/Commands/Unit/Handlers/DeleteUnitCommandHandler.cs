using PropertyRenting.Application.Specifications.Write.Building;

namespace PropertyRenting.Application.Commands.Unit.Handlers;

public class DeleteUnitCommandHandler : IRequestHandler<DeleteUnitCommand, ErrorOr<bool>>
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUnitReadService _unitReadService;

    public DeleteUnitCommandHandler(IBuildingRepository buildingRepository, IUnitOfWork unitOfWork, IUnitReadService unitReadService)
    {
        _buildingRepository = buildingRepository;
        _unitOfWork = unitOfWork;
        _unitReadService = unitReadService;
    }
    public async Task<ErrorOr<bool>> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
    {
        var buildingId = EntityId.Create(request.BuildingId);
        var unitId = EntityId.Create(request.UnitId);

        var inInvalid = ValidatorBuilder.Init().Append(buildingId).Append(unitId).IsInValid(out List<Error> ErrorList);
        if (inInvalid) return ErrorList;

        var building = await _buildingRepository.GetBuildingAsync(new GetBuildingWithUnitsSpecification(buildingId.Value), cancellationToken);
        if (building is null) return Domain.Errors.Errors.Common.NotFoundEntity;


        var deleteResult = await building.DeleteUnit(unitId.Value, _unitReadService);
        if (deleteResult.IsError) return deleteResult.FirstError;

        _buildingRepository.Update(building);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
