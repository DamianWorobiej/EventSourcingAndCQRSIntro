namespace Common.Queries.Products;

public class GetProductDetailsQuery : Query
{
    public Guid ProductId { get; set; }

    public GetProductDetailsQuery(Guid productId)
    {
        ProductId = productId;
    }
}
