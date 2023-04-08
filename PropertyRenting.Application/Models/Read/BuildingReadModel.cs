namespace PropertyRenting.Application.Models.Read;

public class BuildingReadModel : BaseReadModel
{
    public string Symbol { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public BuildingType BuildingType { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid DistrictId { get; set; }
    public string Address { get; set; }
    public string Location { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public ConstructionStatus ConstructionStatus { get; set; }
    public int? EstablishYear { get; set; }
    public decimal? TotalArea { get; set; }
    public decimal? RentableArea { get; set; }
    public decimal? YearRentAmount { get; set; }
    public decimal? YearReRentAmount { get; set; }
    public int? LevelsNumber { get; set; }
    public int? UnitsNumber { get; set; }
    public DateOnly? ReceiveDate { get; set; }
    public string Notes { get; set; }

    public EmployeeReadModel Employee { get; set; }
    public DistrictReadModel District { get; set; }
    public IReadOnlyCollection<BuildingContributerReadModel> Contributers { get; set; }
    public IReadOnlyCollection<UnitReadModel> Units { get; set; }
}
