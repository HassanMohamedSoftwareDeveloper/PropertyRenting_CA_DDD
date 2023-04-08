namespace PropertyRenting.Application.Models.Read;

public class BuildingContributerReadModel : BaseReadModel
{
    public Guid ContributerId { get; set; }
    public Guid BuildingId { get; set; }
    public decimal Percentage { get; set; }

    public ContributerReadModel Contributer { get; set; }
    public BuildingReadModel Building { get; set; }
}
