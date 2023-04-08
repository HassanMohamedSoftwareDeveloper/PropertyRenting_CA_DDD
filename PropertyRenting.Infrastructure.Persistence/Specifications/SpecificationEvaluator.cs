using Microsoft.EntityFrameworkCore;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Infrastructure.Persistence.Specifications;

internal static class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQueryable, ISpecification<TEntity> specification) where TEntity : class
    {
        if (specification is null) return inputQueryable;

        IQueryable<TEntity> queryable = inputQueryable;

        if (specification.Criteria is not null) queryable = queryable.Where(specification.Criteria);

        queryable = specification.IncludeExpressions.Aggregate(queryable, (current, includeExpression)
            => current.Include(includeExpression));

        if (specification.OrderByExpresion is not null) queryable = queryable.OrderBy(specification.OrderByExpresion);

        if (specification.OrderByDescendingExpresion is not null) queryable = queryable.OrderBy(specification.OrderByDescendingExpresion);

        if (specification.IsSplitQuery) queryable = queryable.AsSplitQuery();

        if (specification.AsNoTracking) queryable = queryable.AsNoTracking();

        return queryable;
    }
}
