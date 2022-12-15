namespace Framework.Domain.Abstraction;

public interface IAggregateRoot
{
    IReadOnlyList<IDomainEvent> UnCommittedEvnEvents { get; }
}