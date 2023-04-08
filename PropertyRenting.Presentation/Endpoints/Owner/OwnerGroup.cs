namespace PropertyRenting.Presentation.Endpoints.Owner;

internal sealed class OwnerGroup : Group
{
    public OwnerGroup()
    {
        Configure("owners", ep => { });
    }
}
