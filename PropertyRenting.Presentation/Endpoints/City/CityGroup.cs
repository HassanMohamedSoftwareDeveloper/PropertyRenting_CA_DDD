namespace PropertyRenting.Presentation.Endpoints.City;

internal sealed class CityGroup : Group
{
    public CityGroup()
    {
        Configure("cities", ep => { });
    }
}
