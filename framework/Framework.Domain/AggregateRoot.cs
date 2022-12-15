using Framework.Domain.Abstraction;

namespace Framework.Domain;

public class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
{
    private List<IDomainEvent> _UncommittedEvents;
    public IReadOnlyList<IDomainEvent> UnCommittedEvnEvents => _UncommittedEvents.AsReadOnly();

    public AggregateRoot()
    {
        _UncommittedEvents = new List<IDomainEvent>();
    }

}