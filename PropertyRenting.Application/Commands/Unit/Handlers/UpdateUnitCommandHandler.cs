using PropertyRenting.Application.Specifications.Write.Building;
using PropertyRenting.Domain.ValueObjects.Building;

namespace PropertyRenting.Application.Commands.Unit.Handlers;

public class UpdateUnitCommandHandler : IRequestHandler<UpdateUnitCommand, ErrorOr<bool>>
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUnitReadService _unitReadService;

    public UpdateUnitCommandHandler(IBuildingRepository buildingRepository, IUnitOfWork unitOfWork, IUnitReadService unitReadService)
    {
        _buildingRepository = buildingRepository;
        _unitOfWork = unitOfWork;
        _unitReadService = unitReadService;
    }
    public async Task<ErrorOr<bool>> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
    {
        var unitId = EntityId.Create(request.UnitId);
        var unitNumber = UnitNumber.Create(request.UnitNumber);
        var unitName = UnitName.Create(request.UnitName);
        var buildingId = EntityId.Create(request.BuildingId);
        var districtId = EntityId.Create(request.DistrictId);

        var inInvalid = ValidatorBuilder.Init().Append(unitId)
            .Append(unitNumber)
            .Append(unitName)
            .Append(buildingId)
            .Append(districtId)
            .IsInValid(out List<Error> ErrorList);
        if (inInvalid) return ErrorList;


        var building = await _buildingRepository.GetBuildingAsync(new GetBuildingWithUnitsSpecification(buildingId.Value), cancellationToken);
        if (building is null) return Domain.Errors.Errors.Common.NotFoundEntity;

        var updateResult = await building.UpdateUnit(unitId.Value, unitNumber.Value, unitName.Value, request.IsActive, request.ReceiveDate, districtId.Value, request.Address, request.AnnualRentAmount,
            request.TotalArea, request.RentableArea, request.HasCentralAC, request.HasInternetService, request.FloorNumber, request.RoomsNumber, request.ACsNumber,
            request.HallsNumber, request.PathsNumber, request.KitchensNumber, _unitReadService);

        if (updateResult.IsError) return updateResult.FirstError;

        _buildingRepository.Update(building);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
