using Mapster;
using PropertyRenting.Application.Commands.Unit;

namespace PropertyRenting.API.Endpoints.Unit.Commands.Update;

internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, UpdateUnitCommand>();
    }
}
