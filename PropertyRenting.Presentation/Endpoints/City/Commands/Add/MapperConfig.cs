using Mapster;
using PropertyRenting.Application.Commands.City;

namespace PropertyRenting.Presentation.Endpoints.City.Commands.Add;

internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, AddCityCommand>();
    }
}
