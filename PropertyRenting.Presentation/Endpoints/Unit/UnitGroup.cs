namespace PropertyRenting.Presentation.Endpoints.Unit;

public class UnitGroup : Group
{
    public UnitGroup()
    {
        Configure("units", ep => { });
    }
}
