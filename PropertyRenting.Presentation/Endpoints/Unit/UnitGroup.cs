namespace PropertyRenting.API.Endpoints.Unit;

public class UnitGroup : Group
{
    public UnitGroup()
    {
        Configure("units", ep => { });
    }
}
