namespace PropertyRenting.API.Endpoints.Renter;

internal sealed class RenterGroup : Group
{
    public RenterGroup()
    {
        Configure("renters", ep => { });
    }
}