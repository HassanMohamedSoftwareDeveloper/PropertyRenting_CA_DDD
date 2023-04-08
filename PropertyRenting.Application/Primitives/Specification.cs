using PropertyRenting.Domain.Primitives;
using System.Linq.Expressions;

namespace PropertyRenting.Application.Primitives;

internal abstract class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
{
    #region CTORS :
    protected Specification(Expression<Func<TEntity, bool>> criteria) => Criteria = criteria;
    #endregion

    #region PROPS :
    public bool IsSplitQuery { get; set; }
    public bool AsNoTracking { get; set; }

    public Expression<Func<TEntity, bool>> Criteria { get; private set; }
    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; private set; } = new();
    public List<string> IncludeProperties { get; private set; } = new();
    public Expression<Func<TEntity, object>> OrderByExpresion { get; private set; }
    public Expression<Func<TEntity, object>> OrderByDescendingExpresion { get; private set; }
    #endregion

    #region Methods :
    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        => IncludeExpressions.Add(includeExpression);
    protected void AddInclude(string propertyName)
      => IncludeProperties.Add(propertyName);
    protected void AddOrderBy(Expression<Func<TEntity, object>> orderBy)
       => OrderByExpresion = orderBy;
    protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescending)
      => OrderByDescendingExpresion = orderByDescending;
    #endregion
}