namespace Common.Queries.Transactions;

public class GetProductTransactionsQuery : Query
{
    public Guid ProductId { get; set; }

    public GetProductTransactionsQuery(Guid productId)
    {
        ProductId = productId;
    }
}
