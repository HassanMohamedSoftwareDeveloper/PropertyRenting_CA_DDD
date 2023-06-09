﻿using Mapster;
using PropertyRenting.Application.Commands.Contributer;

namespace PropertyRenting.API.Endpoints.Contributer.Commands.Update;


internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, UpdateContributerCommand>();
    }

}