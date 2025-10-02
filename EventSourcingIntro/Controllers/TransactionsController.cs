using BusinessLayer.CommandHandlers;
using BusinessLayer.QueryHandlers;
using Common.Commands;
using Common.DTOs.Transactions;
using Common.Queries.Transactions;
using EventSourcingIntro.Requests.Transactions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventSourcingIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ICommandHandler<AddTransactionCommand> _addTransactionCommandHandler;
        private readonly IQueryHandler<GetProductTransactionsQuery, IEnumerable<TransactionDto>> _getProductTransactionsQueryHandler;

        public TransactionsController(
            ICommandHandler<AddTransactionCommand> addTransactionCommandHandler,
            IQueryHandler<GetProductTransactionsQuery, IEnumerable<TransactionDto>> getProductTransactionsQueryHandler)
        {
            _addTransactionCommandHandler = addTransactionCommandHandler;
            _getProductTransactionsQueryHandler = getProductTransactionsQueryHandler;
        }


        // GET api/<TransactionsController>/{Guid}
        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(Guid productId)
        {
            var transactions = await _getProductTransactionsQueryHandler.Handle(new GetProductTransactionsQuery(productId));

            return Ok(transactions);
        }

        // POST api/<TransactionsController>/{Guid}
        [HttpPost("{productId}")]
        public async Task<IActionResult> Post(Guid productId, [FromBody] AddTransactionRequest value)
        {
            await _addTransactionCommandHandler.Handle(new AddTransactionCommand(productId, value.Quantity));

            return Created();
        }
    }
}
