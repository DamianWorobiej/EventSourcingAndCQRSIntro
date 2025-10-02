using Common.Events.Transactions;
using Common.Helpers;
using DataLayer.Entities;
using DataLayer.EventStores;
using DataLayer.ReadModels;

namespace DataLayer.EventHandlers.Transactions;

public class TransactionAddedEventHandler : IEventHandler<TransactionAddedEvent>
{
    private readonly IEventStore _eventStore;
    private readonly IReadModel _readModel;
    private readonly IDateTimeHelper _dateTimeHelper;

    public TransactionAddedEventHandler(IEventStore eventStore, IReadModel readModel, IDateTimeHelper dateTimeHelper)
    {
        _eventStore = eventStore;
        _readModel = readModel;
        _dateTimeHelper = dateTimeHelper;
    }

    public async Task Handle(TransactionAddedEvent @event)
    {
        await _eventStore.SaveEventAsync(@event);

        var transaction = new Transaction()
        {
            Id = _readModel.Transactions.Count + 1,
            ProductId = @event.ProductId,
            Quantity = @event.StockChange,
            OcurredAt = _dateTimeHelper.GetUtcNow(),
        };

        _readModel.Transactions.Add(transaction);
    }
}
