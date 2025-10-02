using Common.DTOs.Product;
using Common.Queries.Products;
using DataLayer.ReadModels;

namespace BusinessLayer.QueryHandlers.Products;

public class GetProductDetailsQueryHandler : IQueryHandler<GetProductDetailsQuery, ProductDetailsDto>
{
    private readonly IReadModel _readModel;

    public GetProductDetailsQueryHandler(IReadModel readModel)
    {
        _readModel = readModel;
    }

    public async Task<ProductDetailsDto> Handle(GetProductDetailsQuery query)
    {
        var productEntity = await Task.Run(() => _readModel.Products.FirstOrDefault(x => x.Id == query.ProductId));
        if (productEntity is null)
        {
            // Handle missing product
            throw new NullReferenceException("No product found");
        }

        var product = new ProductDetailsDto
        {
            Name = productEntity.Name,
            Price = productEntity.Price,
            CreatedAt = productEntity.CreatedAt,
            UpdatedAt = productEntity.UpdatedAt,
            Quantity = await Task.Run(() => _readModel.Transactions.Where(x => x.ProductId == query.ProductId).Sum(x => x.Quantity))
        };

        return product;
    }
}
