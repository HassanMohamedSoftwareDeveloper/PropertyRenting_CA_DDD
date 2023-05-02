using Mapster;
using PropertyRenting.Application.Commands.Employee;

namespace PropertyRenting.API.Endpoints.Employee.Commands.Update;


internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, UpdateEmployeeCommand>();
    }

}