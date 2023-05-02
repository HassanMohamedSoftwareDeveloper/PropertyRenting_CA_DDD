namespace PropertyRenting.API.Endpoints.Unit.Commands.Update;

internal record Request
{
    [BindFrom("UnitId")]
    public Guid Id { get; init; }
    public Guid BuildingId { get; init; }
    public string UnitNumber { get; set; }
    public string UnitName { get; set; }
    public bool IsActive { get; set; }
    public bool IsRented { get; set; }
    public DateOnly? ReceiveDate { get; set; }
    public Guid DistrictId { get; set; }
    public string Address { get; set; }
    public decimal? AnnualRentAmount { get; set; }
    public decimal? TotalArea { get; set; }
    public decimal? RentableArea { get; set; }
    public bool HasCentralAC { get; set; }
    public bool HasInternetService { get; set; }
    public uint? FloorNumber { get; set; }
    public uint? RoomsNumber { get; set; }
    public uint? ACsNumber { get; set; }
    public uint? HallsNumber { get; set; }
    public uint? PathsNumber { get; set; }
    public uint? KitchensNumber { get; set; }
}
internal class Validator : AbstractValidator<Request>
{
    public Validator()
    {
    }
}