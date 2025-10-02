namespace Common.Commands;

public class CreateProductCommand : Command
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public CreateProductCommand(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

public class UpdateProductCommand : Command
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public UpdateProductCommand(Guid productId, string name, decimal price)
    {
        ProductId = productId;
        Name = name;
        Price = price;
    }
}
