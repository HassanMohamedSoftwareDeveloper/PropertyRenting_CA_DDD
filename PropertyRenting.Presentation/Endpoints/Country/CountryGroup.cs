namespace PropertyRenting.Presentation.Endpoints.Country;

internal sealed class CountryGroup : Group
{
    public CountryGroup()
    {
        Configure("countries", ep => { });
    }
}
