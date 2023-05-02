using Carter;

namespace PropertyRenting.API.Endpoints;

public interface IGroupEndpoint : ICarterModule
{
    public RouteGroupBuilder RouteGroup { get; }
    RouteGroupBuilder CreateRouteGroup(IEndpointRouteBuilder app);
}
