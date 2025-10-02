namespace Common.Events.Transactions;

public class TransactionAddedEvent : Event
{
    public Guid ProductId { get; set; }
    public int StockChange { get; set; }

    public override Guid StreamId => ProductId;


    public TransactionAddedEvent(Guid productId, int stockChange)
    {
        ProductId = productId;
        StockChange = stockChange;
    }
}
