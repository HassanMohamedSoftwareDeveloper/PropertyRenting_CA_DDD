namespace PropertyRenting.Presentation.Endpoints.Renter;

internal sealed class RenterGroup : Group
{
    public RenterGroup()
    {
        Configure("renters", ep => { });
    }
}