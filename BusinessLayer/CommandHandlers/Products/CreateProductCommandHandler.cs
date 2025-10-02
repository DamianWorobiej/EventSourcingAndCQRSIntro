using Common.Commands;
using Common.Events.Products;
using DataLayer.EventHandlers;

namespace BusinessLayer.CommandHandlers.Products;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IEventHandler<ProductCreatedEvent> _eventHandler;

    public CreateProductCommandHandler(IEventHandler<ProductCreatedEvent> eventHandler)
    {
        _eventHandler = eventHandler;
    }

    public async Task Handle(CreateProductCommand command)
    {
        var @event = new ProductCreatedEvent(command.Name, command.Price);

        // probably should add this event to a queue that would call the event handler instead
        await _eventHandler.Handle(@event);
    }
}
