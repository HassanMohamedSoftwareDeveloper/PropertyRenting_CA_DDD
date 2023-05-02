using Mapster;
using PropertyRenting.Application.Commands.City;

namespace PropertyRenting.API.Endpoints.City.Commands.Update;

internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, UpdateCityCommand>();
    }
}
