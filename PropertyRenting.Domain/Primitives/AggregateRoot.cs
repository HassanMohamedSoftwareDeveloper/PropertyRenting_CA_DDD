using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Domain.Primitives;

public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    protected AggregateRoot(EntityId id) : base(id)
    {
    }
    protected AggregateRoot() : base()
    {

    }
    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();
    public void ClearDomainEvents() => _domainEvents.Clear();
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
