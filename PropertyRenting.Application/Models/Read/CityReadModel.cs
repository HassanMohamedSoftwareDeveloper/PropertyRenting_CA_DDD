namespace PropertyRenting.Application.Models.Read;

public class CityReadModel : BaseReadModel
{
    public string Name { get; set; }
    public Guid CountryId { get; set; }

    public CountryReadModel Country { get; set; }
    public IReadOnlyCollection<DistrictReadModel> Districts { get; set; }
}
