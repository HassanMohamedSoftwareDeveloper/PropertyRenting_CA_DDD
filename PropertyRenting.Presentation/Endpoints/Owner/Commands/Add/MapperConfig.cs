using Mapster;
using PropertyRenting.Application.Commands.Owner;

namespace PropertyRenting.Presentation.Endpoints.Owner.Commands.Add;

internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, AddOwnerCommand>();
    }

}
