using Common.Events;

namespace DataLayer.EventHandlers;

public interface IEventHandler<T> where T : Event
{
    Task Handle(T @event);
}
