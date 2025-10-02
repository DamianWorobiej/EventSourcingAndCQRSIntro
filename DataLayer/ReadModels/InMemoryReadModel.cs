using DataLayer.Entities;

namespace DataLayer.ReadModels;

public class InMemoryReadModel : IReadModel
{
    private List<Product> Products;
    private List<Transaction> Transactions;

    public InMemoryReadModel()
    {
        Products = new List<Product>();
        Transactions = new List<Transaction>();
    }

    ICollection<Product> IReadModel.Products => Products;

    ICollection<Transaction> IReadModel.Transactions => Transactions;
}
