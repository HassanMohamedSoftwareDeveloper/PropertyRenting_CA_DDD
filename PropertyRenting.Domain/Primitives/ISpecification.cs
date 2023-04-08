using System.Linq.Expressions;

namespace PropertyRenting.Domain.Primitives;

public interface ISpecification<TEntity> where TEntity : class
{
    public bool IsSplitQuery { get; protected set; }
    public bool AsNoTracking { get; protected set; }

    public Expression<Func<TEntity, bool>> Criteria { get; }
    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
    public Expression<Func<TEntity, object>> OrderByExpresion { get; }
    public Expression<Func<TEntity, object>> OrderByDescendingExpresion { get; }
}
