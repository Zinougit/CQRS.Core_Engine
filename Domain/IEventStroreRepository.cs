using CQRS.Core.Event;

namespace CQRS.Core.Domain;

public interface IEventStoreRepository {

    Task SaveAsync(EventModel @event);
    Task<List<EventModel>> GetByAggregatId(Guid id);
}