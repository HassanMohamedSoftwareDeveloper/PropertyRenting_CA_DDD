using Mapster;
using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Models.Read;

namespace PropertyRenting.Application.Common.Mappings.Configurations;

internal sealed class EmployeeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EmployeeReadModel, EmployeeDTO>()
            .Map(dest => dest.EmployeeName, src => src.Name);

        config.NewConfig<EmployeeReadModel, BaseLookupDTO>()
            .Map(dest => dest.Value, src => src.Id)
            .Map(dest => dest.Description, src => src.Name);
    }
}
