using Common.Commands;
using Common.Events.Products;
using DataLayer.EventHandlers;
using DataLayer.EventStores;

namespace BusinessLayer.CommandHandlers.Products;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IEventHandler<ProductUpdatedEvent> _eventHandler;
    private readonly IEventStore _eventStore;

    public UpdateProductCommandHandler(IEventHandler<ProductUpdatedEvent> eventHandler, IEventStore eventStore)
    {
        _eventHandler = eventHandler;
        _eventStore = eventStore;
    }

    public async Task Handle(UpdateProductCommand command)
    {
        var productEvents = await _eventStore.GetEventsAsync(command.ProductId);
        if (!productEvents.Any())
        {
            throw new NullReferenceException("No product found");
        }

        var @event = new ProductUpdatedEvent(command.Id, command.Name, command.Price);

        // probably should add this event to a queue that would call the event handler instead
        await _eventHandler.Handle(@event);
    }
}
