using Mapster;
using PropertyRenting.Application.Commands.Building;

namespace PropertyRenting.Presentation.Endpoints.Building.Commands.Add;

internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, AddBuildingCommand>();
    }
}
