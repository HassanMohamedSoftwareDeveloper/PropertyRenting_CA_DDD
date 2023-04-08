using Mapster;

namespace PropertyRenting.Presentation.Endpoints.Country.Commands.Add;

internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, AddCountryCommand>();
    }

}
