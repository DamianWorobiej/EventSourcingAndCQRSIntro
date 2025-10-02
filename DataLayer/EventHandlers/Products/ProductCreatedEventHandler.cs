using Common.Events.Products;
using Common.Helpers;
using DataLayer.Entities;
using DataLayer.EventStores;
using DataLayer.ReadModels;

namespace DataLayer.EventHandlers.Products;

public class ProductCreatedEventHandler : IEventHandler<ProductCreatedEvent>
{
    private readonly IEventStore _eventStore;
    private readonly IReadModel _readModel;
    private readonly IDateTimeHelper _dateTimeHelper;

    public ProductCreatedEventHandler(IEventStore eventStore, IReadModel readModel, IDateTimeHelper dateTimeHelper)
    {
        _eventStore = eventStore;
        _readModel = readModel;
        _dateTimeHelper = dateTimeHelper;
    }

    public async Task Handle(ProductCreatedEvent @event)
    {
        await _eventStore.SaveEventAsync(@event);

        var entity = new Product()
        {
            Id = @event.ProductId,
            Name = @event.Name,
            Price = @event.Price,
            CreatedAt = _dateTimeHelper.GetUtcNow(),
            UpdatedAt = _dateTimeHelper.GetUtcNow(),
        };

        _readModel.Products.Add(entity);
    }
}
