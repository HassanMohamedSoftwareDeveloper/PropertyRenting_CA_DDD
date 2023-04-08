namespace PropertyRenting.Application.Models.Read;

public class CountryReadModel : BaseReadModel
{
    public string Name { get; set; }
    public string Nationality { get; set; }
    public IReadOnlyCollection<CityReadModel> Cities { get; set; }
}
