using CQRS.Core.Event;

namespace CQRS.Core.Producer;
public interface IEventProducer{
    Task ProduceAsync<T> (T @event, string topic) where T : BaseEvent;
}