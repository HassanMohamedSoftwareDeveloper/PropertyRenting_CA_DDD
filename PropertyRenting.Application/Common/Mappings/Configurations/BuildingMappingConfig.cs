using Mapster;
using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Models.Read;

namespace PropertyRenting.Application.Common.Mappings.Configurations;

internal sealed class BuildingMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<BuildingReadModel, BuildingReadDTO>()
            .Map(dest => dest.District, src => src.District.Name)
            .Map(dest => dest.City, src => src.District.City.Name)
            .Map(dest => dest.Country, src => src.District.City.Country.Name)
            .Map(dest => dest.ConstructionStatus, src => src.ConstructionStatus.Name)
            .Map(dest => dest.Employee, src => src.Employee.Name)
            .Map(dest => dest.Type, src => src.BuildingType.Name);

        config.NewConfig<BuildingReadModel, BuildingDTO>()
            .Map(dest => dest.DistrictId, src => src.DistrictId)
            .Map(dest => dest.CityId, src => src.District.CityId)
            .Map(dest => dest.CountryId, src => src.District.City.CountryId)
            .Map(dest => dest.ConstructionStatus, src => src.ConstructionStatus.Value)
            .Map(dest => dest.EmployeeId, src => src.EmployeeId)
            .Map(dest => dest.Type, src => src.BuildingType.Value);

        config.NewConfig<BuildingReadModel, BaseLookupDTO>()
            .Map(dest => dest.Value, src => src.Id)
            .Map(dest => dest.Description, src => $"{src.Symbol} - {src.Name}");

        config.NewConfig<BuildingContributerReadModel, BuildingContributerDTO>();
    }
}
