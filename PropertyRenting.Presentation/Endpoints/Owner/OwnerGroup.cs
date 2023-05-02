namespace PropertyRenting.API.Endpoints.Owner;

internal sealed class OwnerGroup : Group
{
    public OwnerGroup()
    {
        Configure("owners", ep => { });
    }
}
