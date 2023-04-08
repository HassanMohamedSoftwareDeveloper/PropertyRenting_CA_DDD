using Mapster;
using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Models.Read;

namespace PropertyRenting.Application.Common.Mappings.Configurations;

internal sealed class ContributerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ContributerReadModel, ContributerDTO>();

        config.NewConfig<ContributerReadModel, BaseLookupDTO>()
            .Map(dest => dest.Value, src => src.Id)
            .Map(dest => dest.Description, src => src.Name);
    }
}