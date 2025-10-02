using Common.Events;

namespace DataLayer.EventStores;

public interface IEventStore
{
    Task SaveEventAsync(Event @event);
    Task<IEnumerable<Event>> GetEventsAsync(Guid streamId);
}
