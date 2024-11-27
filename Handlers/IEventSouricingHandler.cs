using CQRS.Core.Domain;

namespace CQRS.Core.Handlers;

public interface IEventSourcingHandler<T> {
    Task<T> GetByIdAsync(Guid aggregateId);
    Task SaveAsync(AggregateRoot aggregate);
}