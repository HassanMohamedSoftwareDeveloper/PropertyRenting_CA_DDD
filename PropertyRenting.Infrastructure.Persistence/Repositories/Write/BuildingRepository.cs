﻿using Microsoft.EntityFrameworkCore;
using PropertyRenting.Domain.Aggregates;
using PropertyRenting.Domain.Primitives;
using PropertyRenting.Domain.Repositories;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Write;

public class BuildingRepository : WriteRepository<Building>, IBuildingRepository
{
    public BuildingRepository(PropertyRentingWriteContext context) : base(context)
    {
    }

    public async Task<Building> GetBuildingAsync(ISpecification<Building> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification)
             .SingleOrDefaultAsync(cancellationToken)
             .ConfigureAwait(false);
    }
}
