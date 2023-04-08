﻿using PropertyRenting.Application.Models.Read;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Read;

internal sealed class RenterReadRepository : ReadRepository<RenterReadModel>, IRenterReadRepository
{
    #region CTORS :
    public RenterReadRepository(PropertyRentingReadContext context) : base(context)
    {
    }
    #endregion
}
