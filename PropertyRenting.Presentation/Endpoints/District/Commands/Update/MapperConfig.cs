using Mapster;
using PropertyRenting.Application.Commands.District;

namespace PropertyRenting.Presentation.Endpoints.District.Commands.Update;

internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, UpdateDistrictCommand>();
    }
}
