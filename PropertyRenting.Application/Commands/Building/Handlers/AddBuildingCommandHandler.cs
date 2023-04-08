using PropertyRenting.Domain.ValueObjects.Building;

namespace PropertyRenting.Application.Commands.Building.Handlers;

public class AddBuildingCommandHandler : IRequestHandler<AddBuildingCommand, ErrorOr<bool>>
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBuildingReadService _buildingReadService;

    public AddBuildingCommandHandler(IBuildingRepository buildingRepository, IUnitOfWork unitOfWork, IBuildingReadService buildingReadService)
    {
        _buildingRepository = buildingRepository;
        _unitOfWork = unitOfWork;
        _buildingReadService = buildingReadService;
    }
    public async Task<ErrorOr<bool>> Handle(AddBuildingCommand request, CancellationToken cancellationToken)
    {
        var symbol = BuildingSymbol.Create(request.Symbol);
        var name = BuildingName.Create(request.Name);
        var type = BuildingType.FromValue(request.Type);
        var employeeId = EntityId.Create(request.EmployeeId);
        var districtId = EntityId.Create(request.DistrictId);
        var constructionStatus = ConstructionStatus.FromValue(request.ConstructionStatus);

        List<(ErrorOr<EntityId> ContributerId, ErrorOr<Percentage> Percentage)> contributers = request.Contributers
            .Select(contributer => (EntityId.Create(contributer.ContributerId), Percentage.Create(contributer.Percentage)))
            .ToList();

        bool isInValid = ValidatorBuilder.Init()
              .Append(symbol)
              .Append(name)
              .Append(type, Domain.Errors.Errors.Building.InvalidBuildingType)
              .Append(employeeId)
              .Append(districtId)
              .Append(constructionStatus, Domain.Errors.Errors.Building.InvalidConstructionStatus)
              .Append(contributers.SelectMany(x => new List<ErrorOr<object>>() { x.ContributerId, x.Percentage }).Select(x => x).ToList())
              .IsInValid(out List<Error> ErrorList);

        if (isInValid) return ErrorList;

        var building = await Domain.Aggregates.Building.Create(symbol.Value, name.Value, request.IsActive, type, employeeId.Value, districtId.Value,
            request.Address, request.Location, request.Latitude, request.Longitude, constructionStatus, request.EstablishYear, request.TotalArea,
            request.RentableArea, request.YearRentAmount, request.YearReRentAmount, request.LevelsNumber, request.ReceiveDate, request.Notes,
            _buildingReadService);

        if (building.IsError) return building.FirstError;

        var addContributersRes = building.Value.AddContributers(contributers.Select(contributer => (contributer.ContributerId.Value, contributer.Percentage.Value)).ToList());

        if (addContributersRes.IsError) return addContributersRes.FirstError;

        _buildingRepository.Create(building.Value);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
