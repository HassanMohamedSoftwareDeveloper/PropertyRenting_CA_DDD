using Mapster;

namespace PropertyRenting.API.Endpoints.Country.Commands.Add;

internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, AddCountryCommand>();
    }

}
