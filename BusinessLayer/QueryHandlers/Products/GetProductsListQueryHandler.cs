using Common.DTOs.Product;
using Common.Queries.Products;
using DataLayer.ReadModels;

namespace BusinessLayer.QueryHandlers.Products;

public class GetProductsListQueryHandler : IQueryHandler<GetProductsListQuery, IEnumerable<BasicProductDto>>
{
    private readonly IReadModel _readModel;

    public GetProductsListQueryHandler(IReadModel readModel)
    {
        _readModel = readModel;
    }

    public async Task<IEnumerable<BasicProductDto>> Handle(GetProductsListQuery query)
    {
        // we're doing 2 queries on both all products and all transactions
        // probably worth introducing paging to avoid performance issues in real scenario

        var products = await Task.Run(() => _readModel.Products.Select(x => new BasicProductDto
        {
            ProductId = x.Id,
            Name = x.Name,
            Price = x.Price,
            Quantity = _readModel.Transactions.Where(t => t.ProductId == x.Id).Sum(x => x.Quantity)
        }));

        return products;
    }
}
