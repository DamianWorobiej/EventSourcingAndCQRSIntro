namespace Common.Commands;

public class AddTransactionCommand : Command
{
    public  Guid ProductId { get; set; }
    /// <summary>
    /// Positive if restocked, negative if sold
    /// </summary>
    public int Quantity { get; set; }

    public AddTransactionCommand(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
}
