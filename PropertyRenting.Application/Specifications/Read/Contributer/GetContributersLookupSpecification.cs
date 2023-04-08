﻿using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Specifications.Read.Contributer;

internal sealed class GetContributersLookupSpecification : Specification<ContributerReadModel>, ISpecification<ContributerReadModel>
{
    public GetContributersLookupSpecification() : base(null)
    {
        AddOrderBy(x => x.CreatedAt);
        IsSplitQuery = true;
        AsNoTracking = true;
    }
}