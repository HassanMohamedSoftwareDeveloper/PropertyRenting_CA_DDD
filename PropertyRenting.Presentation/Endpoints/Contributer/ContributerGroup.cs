namespace PropertyRenting.Presentation.Endpoints.Contributer;

internal sealed class ContributerGroup : Group
{
    public ContributerGroup()
    {
        Configure("contributers", ep => { });
    }
}
