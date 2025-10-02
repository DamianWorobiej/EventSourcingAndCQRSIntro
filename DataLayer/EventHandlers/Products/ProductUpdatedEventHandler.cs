using Common.Events.Products;
using Common.Helpers;
using DataLayer.EventStores;
using DataLayer.ReadModels;

namespace DataLayer.EventHandlers.Products;

public class ProductUpdatedEventHandler : IEventHandler<ProductUpdatedEvent>
{
    private readonly IEventStore _eventStore;
    private readonly IReadModel _readModel;
    private readonly IDateTimeHelper _dateTimeHelper;

    public ProductUpdatedEventHandler(IEventStore eventStore, IReadModel readModel, IDateTimeHelper dateTimeHelper)
    {
        _eventStore = eventStore;
        _readModel = readModel;
        _dateTimeHelper = dateTimeHelper;
    }

    public async Task Handle(ProductUpdatedEvent @event)
    {
        await _eventStore.SaveEventAsync(@event);

        var entity = _readModel.Products.FirstOrDefault(x => x.Id == @event.ProductId);
        if (entity is null)
        {
            throw new NullReferenceException("No product found");
        }

        entity.Name = @event.Name;
        entity.Price = @event.Price;
        entity.UpdatedAt = _dateTimeHelper.GetUtcNow();

        // it's all in memory, but we should explicitly persist it in read model here
    }
}
