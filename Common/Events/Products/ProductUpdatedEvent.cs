namespace Common.Events.Products;

public class ProductUpdatedEvent : Event
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override Guid StreamId => ProductId;

    public ProductUpdatedEvent(Guid productId, string name, decimal price)
    {
        ProductId = productId;
        Name = name;
        Price = price;
    }
}
