namespace PropertyRenting.Application.Models.Read;

public class DistrictReadModel : BaseReadModel
{
    public string Name { get; set; }
    public Guid CityId { get; set; }

    public CityReadModel City { get; set; }
}
