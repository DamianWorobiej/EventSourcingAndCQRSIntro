using Common.DTOs.Transactions;
using Common.Queries.Transactions;
using DataLayer.ReadModels;

namespace BusinessLayer.QueryHandlers.Transactions;

public class GetProductTransactionsQueryHandler : IQueryHandler<GetProductTransactionsQuery, IEnumerable<TransactionDto>>
{
    private readonly IReadModel _readModel;

    public GetProductTransactionsQueryHandler(IReadModel readModel)
    {
        _readModel = readModel;
    }

    public async Task<IEnumerable<TransactionDto>> Handle(GetProductTransactionsQuery query)
    {
        var transactions = await Task.Run(() => _readModel.Transactions.Where(x => x.ProductId == query.ProductId));
        var dtos = transactions.Select(x => new TransactionDto()
        {
            Quantity = x.Quantity,
            OcurredAt = x.OcurredAt
        });

        return dtos;
    }
}
