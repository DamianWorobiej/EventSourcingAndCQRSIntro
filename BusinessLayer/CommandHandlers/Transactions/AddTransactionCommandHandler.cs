using Common.Commands;
using Common.Events.Transactions;
using DataLayer.EventHandlers;
using DataLayer.EventStores;

namespace BusinessLayer.CommandHandlers.Transactions;

public class AddTransactionCommandHandler : ICommandHandler<AddTransactionCommand>
{
    private readonly IEventHandler<TransactionAddedEvent> _eventHandler;
    private readonly IEventStore _eventStore;

    public AddTransactionCommandHandler(IEventHandler<TransactionAddedEvent> eventHandler, IEventStore eventStore)
    {
        _eventHandler = eventHandler;
        _eventStore = eventStore;
    }

    public async Task Handle(AddTransactionCommand command)
    {
        var events = await _eventStore.GetEventsAsync(command.ProductId);
        var transactions = events.OfType<TransactionAddedEvent>().ToList();
        var existingQuantity = transactions.Sum(x => x.StockChange);

        if (existingQuantity + command.Quantity < 0)
        {
            throw new ArgumentException("Not enough products in stock");
        }

        // probably should add this event to a queue that would call the event handler instead
        await _eventHandler.Handle(new TransactionAddedEvent(command.ProductId, command.Quantity));
    }
}
