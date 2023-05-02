namespace PropertyRenting.API.Endpoints.Building.Commands.Update;

internal record Request
{
    [BindFrom("BuildingId")]
    public Guid Id { get; init; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int Type { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid DistrictId { get; set; }
    public string Address { get; set; }
    public string Location { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int ConstructionStatus { get; set; }
    public int? EstablishYear { get; set; }
    public decimal? TotalArea { get; set; }
    public decimal? RentableArea { get; set; }
    public decimal? YearRentAmount { get; set; }
    public decimal? YearReRentAmount { get; set; }
    public int? LevelsNumber { get; set; }
    public int? UnitsNumber { get; set; }
    public DateOnly? ReceiveDate { get; set; }
    public string Notes { get; set; }
    public List<BuildingContributer> Contributers { get; set; }
}
internal class BuildingContributer
{
    public Guid ContributerId { get; set; }
    public decimal Percentage { get; set; }
}
internal class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}