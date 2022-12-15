using LoanApplication.Framework.Core.Abstraction;

namespace Framework.Domain.Abstraction;

public interface IDomainEvent : IEvent
{
    Guid EventId { get; }
    DateTime PublishDateTime { get; }
}