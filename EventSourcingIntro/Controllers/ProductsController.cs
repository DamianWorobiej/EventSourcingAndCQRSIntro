using BusinessLayer.CommandHandlers;
using BusinessLayer.QueryHandlers;
using Common.Commands;
using Common.DTOs.Product;
using Common.Queries.Products;
using EventSourcingIntro.Requests.Products;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingIntro.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ICommandHandler<CreateProductCommand> _createCommandHandler;
    private readonly ICommandHandler<UpdateProductCommand> _updateCommandHandler;
    private readonly IQueryHandler<GetProductDetailsQuery, ProductDetailsDto> _getProductDetailsQueryHandler;
    private readonly IQueryHandler<GetProductsListQuery, IEnumerable<BasicProductDto>> _getProductsListQueryHandler;

    public ProductsController(
        ICommandHandler<CreateProductCommand> createCommandHandler,
        ICommandHandler<UpdateProductCommand> updateCommandHandler,
        IQueryHandler<GetProductDetailsQuery, ProductDetailsDto> getProductDetailsQueryHandler,
        IQueryHandler<GetProductsListQuery, IEnumerable<BasicProductDto>> getProductsListQueryHandler)
    {
        _createCommandHandler = createCommandHandler;
        _updateCommandHandler = updateCommandHandler;
        _getProductDetailsQueryHandler = getProductDetailsQueryHandler;
        _getProductsListQueryHandler = getProductsListQueryHandler;
    }

    // GET: api/<ProductsController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _getProductsListQueryHandler.Handle(new GetProductsListQuery());

        return Ok(products);
    }

    // GET api/<ProductsController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var product = await _getProductDetailsQueryHandler.Handle(new GetProductDetailsQuery(id));

        return Ok(product);
    }

    // POST api/<ProductsController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProductRequest request)
    {
        await _createCommandHandler.Handle(new CreateProductCommand(request.Name, request.Price));

        return Created();
    }

    // PUT api/<ProductsController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProductRequest value)
    {
        await _updateCommandHandler.Handle(new UpdateProductCommand(id, value.Name, value.Price));

        return Ok();
    }
}
