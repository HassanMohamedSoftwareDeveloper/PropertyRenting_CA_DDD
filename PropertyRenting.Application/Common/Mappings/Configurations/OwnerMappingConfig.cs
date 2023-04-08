using Mapster;
using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Models.Read;

namespace PropertyRenting.Application.Common.Mappings.Configurations;

internal sealed class OwnerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OwnerReadModel, OwnerDTO>()
            .Map(dest => dest.OwnerName, src => src.Name);

        config.NewConfig<OwnerReadModel, BaseLookupDTO>()
            .Map(dest => dest.Value, src => src.Id)
            .Map(dest => dest.Description, src => src.Name);
    }
}
