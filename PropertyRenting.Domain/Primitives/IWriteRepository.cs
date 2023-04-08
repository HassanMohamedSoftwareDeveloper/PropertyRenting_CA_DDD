using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Domain.Primitives;

public interface IWriteRepository<TEntity> where TEntity : AggregateRoot
{
    Task<TEntity> GetEntityByIdAsync(EntityId id, CancellationToken cancellationToken = default);
    void Create(TEntity entity);
    void CreateList(List<TEntity> entities);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void DeleteList(List<TEntity> entities);
}
