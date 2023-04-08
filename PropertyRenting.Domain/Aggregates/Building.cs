using PropertyRenting.Domain.Entities.Building;
using PropertyRenting.Domain.Enums;
using PropertyRenting.Domain.ValueObjects.Building;
using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Domain.Aggregates;

public class Building : AggregateRoot
{
    #region Fields :
    private readonly List<BuildingContributer> _contributers = new();
    private readonly List<Unit> _units = new();
    #endregion

    #region CTORS :
    private Building()
    {

    }
    private Building(EntityId id,
                     BuildingSymbol symbol,
                     BuildingName name,
                     bool isActive,
                     BuildingType type,
                     EntityId employeeId,
                     EntityId districtId,
                     string address,
                     string location,
                     string latitude,
                     string longitude,
                     ConstructionStatus constructionStatus,
                     int? establishYear,
                     decimal? totalArea,
                     decimal? rentableArea,
                     decimal? yearRentAmount,
                     decimal? yearReRentAmount,
                     int? levelsNumber,
                     DateOnly? receiveDate,
                     string notes) : base(id)
    {
        Symbol = symbol;
        Name = name;
        IsActive = isActive;
        Type = type;
        EmployeeId = employeeId;
        DistrictId = districtId;
        Address = address;
        Location = location;
        Latitude = latitude;
        Longitude = longitude;
        ConstructionStatus = constructionStatus;
        EstablishYear = establishYear;
        TotalArea = totalArea;
        RentableArea = rentableArea;
        YearRentAmount = yearRentAmount;
        YearReRentAmount = yearReRentAmount;
        LevelsNumber = levelsNumber;
        ReceiveDate = receiveDate;
        Notes = notes;
    }
    #endregion

    #region PROPS :
    public BuildingSymbol Symbol { get; private set; }
    public BuildingName Name { get; private set; }
    public bool IsActive { get; private set; }
    public BuildingType Type { get; private set; }
    public EntityId EmployeeId { get; private set; }
    public EntityId DistrictId { get; private set; }
    public string Address { get; private set; }
    public string Location { get; private set; }
    public string Latitude { get; private set; }
    public string Longitude { get; private set; }
    public ConstructionStatus ConstructionStatus { get; private set; }
    public int? EstablishYear { get; private set; }
    public decimal? TotalArea { get; private set; }
    public decimal? RentableArea { get; private set; }
    public decimal? YearRentAmount { get; private set; }
    public decimal? YearReRentAmount { get; private set; }
    public int? LevelsNumber { get; private set; }
    public int? UnitsNumber { get; private set; }
    public DateOnly? ReceiveDate { get; private set; }
    public string Notes { get; private set; }
    public IReadOnlyCollection<BuildingContributer> Contributers => _contributers.AsReadOnly();
    public IReadOnlyCollection<Unit> Units => _units.AsReadOnly();
    #endregion

    #region Methods :
    public static async Task<ErrorOr<Building>> Create(BuildingSymbol symbol,
                                                       BuildingName name,
                                                       bool isActive,
                                                       BuildingType type,
                                                       EntityId employeeId,
                                                       EntityId districtId,
                                                       string address,
                                                       string location,
                                                       string latitude,
                                                       string longitude,
                                                       ConstructionStatus constructionStatus,
                                                       int? establishYear,
                                                       decimal? totalArea,
                                                       decimal? rentableArea,
                                                       decimal? yearRentAmount,
                                                       decimal? yearReRentAmount,
                                                       int? levelsNumber,
                                                       DateOnly? receiveDate,
                                                       string notes,
                                                       IBuildingReadService buildingReadService)
    {
        bool symbolIsExisted = await buildingReadService.ExistsBySymbolAsync(null, symbol);
        if (symbolIsExisted)
            return Errors.Errors.Building.ExistSymbol;

        return new Building(EntityId.Create(Guid.NewGuid()).Value,
                            symbol,
                            name,
                            isActive,
                            type,
                            employeeId,
                            districtId,
                            address,
                            location,
                            latitude,
                            longitude,
                            constructionStatus,
                            establishYear,
                            totalArea,
                            rentableArea,
                            yearRentAmount,
                            yearReRentAmount,
                            levelsNumber,
                            receiveDate,
                            notes);
    }
    public async Task<ErrorOr<Building>> Update(BuildingSymbol symbol,
                                                BuildingName name,
                                                bool isActive,
                                                BuildingType type,
                                                EntityId employeeId,
                                                EntityId districtId,
                                                string address,
                                                string location,
                                                string latitude,
                                                string longitude,
                                                ConstructionStatus constructionStatus,
                                                int? establishYear,
                                                decimal? totalArea,
                                                decimal? rentableArea,
                                                decimal? yearRentAmount,
                                                decimal? yearReRentAmount,
                                                int? levelsNumber,
                                                DateOnly? receiveDate,
                                                string notes,
                                                IBuildingReadService buildingReadService)
    {
        bool symbolIsExisted = await buildingReadService.ExistsBySymbolAsync(Id, symbol);
        if (symbolIsExisted)
            return Errors.Errors.Building.ExistSymbol;

        Symbol = symbol;
        Name = name;
        IsActive = isActive;
        Type = type;
        EmployeeId = employeeId;
        DistrictId = districtId;
        Address = address;
        Location = location;
        Latitude = latitude;
        Longitude = longitude;
        ConstructionStatus = constructionStatus;
        EstablishYear = establishYear;
        TotalArea = totalArea;
        RentableArea = rentableArea;
        YearRentAmount = yearRentAmount;
        YearReRentAmount = yearReRentAmount;
        LevelsNumber = levelsNumber;
        ReceiveDate = receiveDate;
        Notes = notes;

        return this;
    }


    public ErrorOr<bool> AddContributers(List<(EntityId ContributerId, Percentage Percentage)> contributers)
    {
        decimal totalPercentage = contributers.Sum(x => x.Percentage.Value);
        if (totalPercentage > 100)
            return Errors.Errors.Building.InvalidPercentage;

        _contributers.Clear();

        var contributersList = contributers
            .Select(contributor => BuildingContributer.Create(contributor.ContributerId, contributor.Percentage))
            .ToList();

        _contributers.AddRange(contributersList);

        return true;
    }

    public async Task<ErrorOr<bool>> AddUnit(UnitNumber unitNumber,
                                             UnitName unitName,
                                             bool isActive,
                                             DateOnly? receiveDate,
                                             EntityId districtId,
                                             string address,
                                             decimal? annualRentAmount,
                                             decimal? totalArea,
                                             decimal? rentableArea,
                                             bool hasCentralAC,
                                             bool hasInternetService,
                                             uint? floorNumber,
                                             uint? roomsNumber,
                                             uint? aCsNumber,
                                             uint? hallsNumber,
                                             uint? pathsNumber,
                                             uint? kitchensNumber,
                                             IUnitReadService unitReadService)
    {
        var isExist = await unitReadService.ExistsByUnitNumberAsync(null, unitNumber);
        if (isExist)
            return Errors.Errors.Building.Unit.ExistUnitNumber;
        var unit = Unit.Create(unitNumber, unitName, isActive, receiveDate, districtId, address,
            annualRentAmount, totalArea, rentableArea, hasCentralAC, hasInternetService, floorNumber, roomsNumber, aCsNumber, hallsNumber, pathsNumber, kitchensNumber);

        _units.Add(unit);

        this.UnitsNumber = Units.Count;

        return true;
    }
    public async Task<ErrorOr<bool>> UpdateUnit(EntityId unitId,
                                                UnitNumber unitNumber,
                                                UnitName unitName,
                                                bool isActive,
                                                DateOnly? receiveDate,
                                                EntityId districtId,
                                                string address,
                                                decimal? annualRentAmount,
                                                decimal? totalArea,
                                                decimal? rentableArea,
                                                bool hasCentralAC,
                                                bool hasInternetService,
                                                uint? floorNumber,
                                                uint? roomsNumber,
                                                uint? aCsNumber,
                                                uint? hallsNumber,
                                                uint? pathsNumber,
                                                uint? kitchensNumber,
                                                IUnitReadService unitReadService)
    {
        var unit = Units.SingleOrDefault(x => x.Id == unitId);
        if (unit is null)
            return Errors.Errors.Common.NotFoundEntity;

        var isExist = await unitReadService.ExistsByUnitNumberAsync(unitId, unitNumber);
        if (isExist)
            return Errors.Errors.Building.Unit.ExistUnitNumber;

        unit.Update(unitNumber, unitName, isActive, receiveDate, districtId, address,
            annualRentAmount, totalArea, rentableArea, hasCentralAC, hasInternetService, floorNumber, roomsNumber, aCsNumber, hallsNumber, pathsNumber, kitchensNumber);

        return true;
    }

    public async Task<ErrorOr<bool>> DeleteUnit(EntityId unitId, IUnitReadService unitReadService)
    {
        var unit = Units.SingleOrDefault(x => x.Id == unitId);
        if (unit is null)
            return Errors.Errors.Common.NotFoundEntity;

        var canDelete = await unitReadService.CanDeleteAsync(unitId);
        if (canDelete is false)
            return Errors.Errors.Common.HasTransactions;

        _units.Remove(unit);

        this.UnitsNumber = Units.Count;

        return true;
    }
    #endregion
}
