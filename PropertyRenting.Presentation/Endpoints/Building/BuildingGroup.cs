namespace PropertyRenting.API.Endpoints.Building;

public class BuildingGroup : Group
{
    public BuildingGroup()
    {
        Configure("buildings", ep => { });
        //Configure("buildings", ep =>
        //{
        //    ep.Description(x => x
        //      //.Produces(401)
        //      .WithTags("Building"));
        //});
    }
}
