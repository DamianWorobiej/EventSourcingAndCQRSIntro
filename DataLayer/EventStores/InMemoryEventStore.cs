using Common.Events;

namespace DataLayer.EventStores;

public class InMemoryEventStore : IEventStore
{
    private readonly Dictionary<Guid, IEnumerable<Event>> Events = new();

    public async Task<IEnumerable<Event>> GetEventsAsync(Guid streamId)
    {
        return await Task.Run(() =>
        {
            if (!Events.TryGetValue(streamId, out var events))
            {
                return [];
            }

            return events;
        });
    }

    public async Task SaveEventAsync(Event @event)
    {
        await Task.Run(() =>
        {
            if (!Events.TryGetValue(@event.StreamId, out var events))
            {
                events = [];
                Events.Add(@event.StreamId, events);
            }

            Events[@event.StreamId] = events.Append(@event);
        });

    }
}
