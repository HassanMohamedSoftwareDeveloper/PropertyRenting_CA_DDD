using Carter;

namespace PropertyRenting.Presentation.Endpoints;

public interface IGroupEndpoint : ICarterModule
{
    public RouteGroupBuilder RouteGroup { get; }
    RouteGroupBuilder CreateRouteGroup(IEndpointRouteBuilder app);
}
