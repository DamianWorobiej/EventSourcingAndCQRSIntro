namespace Common.Events.Products;

public class ProductCreatedEvent : Event
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override Guid StreamId => ProductId;

    public ProductCreatedEvent(string name, decimal price)
    {
        ProductId = Guid.NewGuid();
        Name = name;
        Price = price;
    }
}
