using CQRS.Core.Event;

namespace CQRS.Core.Infrastructure;
public interface IEventStore{
    Task SaveEventAsync(IEnumerable<BaseEvent> events, int version, Guid id);
    Task<List<BaseEvent>> GetEventsAsynsc(Guid AggregateId);
}