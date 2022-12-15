using Framework.Domain.Abstraction;

namespace Framework.Domain;

public class DomainEvent : IDomainEvent
{
    public Guid EventId { get; }
    public DateTime PublishDateTime { get; }

    public DomainEvent()
    {
        PublishDateTime = DateTime.Now;
        EventId = Guid.NewGuid();
    }
}