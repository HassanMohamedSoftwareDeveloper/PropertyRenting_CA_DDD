using PropertyRenting.Domain.ValueObjects.Building;
using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Domain.Entities.Building;

public class Unit : Entity
{
    #region CTORS :
    private Unit()
    {

    }
    private Unit(EntityId id,
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
                 uint? kitchensNumber) : base(id)
    {
        UnitNumber = unitNumber;
        UnitName = unitName;
        IsActive = isActive;
        ReceiveDate = receiveDate;
        DistrictId = districtId;
        Address = address;
        AnnualRentAmount = annualRentAmount;
        TotalArea = totalArea;
        RentableArea = rentableArea;
        HasCentralAC = hasCentralAC;
        HasInternetService = hasInternetService;
        FloorNumber = floorNumber;
        RoomsNumber = roomsNumber;
        ACsNumber = aCsNumber;
        HallsNumber = hallsNumber;
        PathsNumber = pathsNumber;
        KitchensNumber = kitchensNumber;
    }
    #endregion

    #region PROPS :
    public UnitNumber UnitNumber { get; private set; }
    public UnitName UnitName { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsRented { get; private set; }
    public DateOnly? ReceiveDate { get; private set; }
    public EntityId DistrictId { get; private set; }
    public string Address { get; private set; }
    public decimal? AnnualRentAmount { get; private set; }
    public decimal? TotalArea { get; private set; }
    public decimal? RentableArea { get; private set; }
    public bool HasCentralAC { get; private set; }
    public bool HasInternetService { get; private set; }
    public uint? FloorNumber { get; private set; }
    public uint? RoomsNumber { get; private set; }
    public uint? ACsNumber { get; private set; }
    public uint? HallsNumber { get; private set; }
    public uint? PathsNumber { get; private set; }
    public uint? KitchensNumber { get; private set; }
    #endregion


    #region Methods :
    internal static Unit Create(UnitNumber unitNumber,
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
                                uint? kitchensNumber)
    {

        return new Unit(EntityId.Create(Guid.NewGuid()).Value, unitNumber, unitName, isActive, receiveDate, districtId, address, annualRentAmount, totalArea, rentableArea, hasCentralAC, hasInternetService, floorNumber, roomsNumber, aCsNumber,
            hallsNumber, pathsNumber, kitchensNumber);
    }

    internal void Update(UnitNumber unitNumber,
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
                         uint? kitchensNumber)
    {

        UnitNumber = unitNumber;
        UnitName = unitName;
        IsActive = isActive;
        ReceiveDate = receiveDate;
        DistrictId = districtId;
        Address = address;
        AnnualRentAmount = annualRentAmount;
        TotalArea = totalArea;
        RentableArea = rentableArea;
        HasCentralAC = hasCentralAC;
        HasInternetService = hasInternetService;
        FloorNumber = floorNumber;
        RoomsNumber = roomsNumber;
        ACsNumber = aCsNumber;
        HallsNumber = hallsNumber;
        PathsNumber = pathsNumber;
        KitchensNumber = kitchensNumber;
    }


    internal void MarkRented()
    {
        this.IsRented = true;
    }
    internal void MarkUnRented()
    {
        this.IsRented = false;
    }
    #endregion
}
