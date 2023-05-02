using Mapster;
using PropertyRenting.Application.Commands.Contributer;

namespace PropertyRenting.API.Endpoints.Contributer.Commands.Add;

internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, AddContributerCommand>();
    }

}
