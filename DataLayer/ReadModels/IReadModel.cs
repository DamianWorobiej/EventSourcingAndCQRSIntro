using DataLayer.Entities;

namespace DataLayer.ReadModels;

public interface IReadModel
{
    ICollection<Product> Products { get; }
    ICollection<Transaction> Transactions { get; }
}
