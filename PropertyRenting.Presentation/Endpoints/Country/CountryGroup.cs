namespace PropertyRenting.API.Endpoints.Country;

internal sealed class CountryGroup : Group
{
    public CountryGroup()
    {
        Configure("countries", ep => { });
    }
}
