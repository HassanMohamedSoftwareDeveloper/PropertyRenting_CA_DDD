using Microsoft.EntityFrameworkCore;
using PropertyRenting.Domain.Primitives;
using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Infrastructure.Persistence.Contexts;
using PropertyRenting.Infrastructure.Persistence.Specifications;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Write;

public abstract class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : AggregateRoot
{
    #region Fields :
    protected readonly PropertyRentingWriteContext Context;
    protected readonly DbSet<TEntity> EntitySet;
    #endregion

    #region CTORS :
    protected WriteRepository(PropertyRentingWriteContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));

        Context = context;
        EntitySet = Context.Set<TEntity>();
    }
    #endregion

    #region Methods :
    public async Task<TEntity> GetEntityByIdAsync(EntityId id, CancellationToken cancellationToken = default)
        => await EntitySet.Where(x => x.Id == id).SingleOrDefaultAsync(cancellationToken);
    public void Create(TEntity entity)
        => EntitySet.Add(entity);
    public void CreateList(List<TEntity> entities)
        => EntitySet.AddRange(entities);
    public void Update(TEntity entity)
        => EntitySet.Update(entity);
    public void Delete(TEntity entity)
        => EntitySet.Remove(entity);
    public void DeleteList(List<TEntity> entities)
        => EntitySet.RemoveRange(entities);

    protected IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        => SpecificationEvaluator.GetQuery(EntitySet.AsQueryable(), specification);
    #endregion
}
