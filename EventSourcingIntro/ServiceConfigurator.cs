using BusinessLayer.CommandHandlers;
using BusinessLayer.CommandHandlers.Products;
using BusinessLayer.CommandHandlers.Transactions;
using BusinessLayer.QueryHandlers;
using BusinessLayer.QueryHandlers.Products;
using BusinessLayer.QueryHandlers.Transactions;
using Common.Commands;
using Common.DTOs.Product;
using Common.DTOs.Transactions;
using Common.Events.Products;
using Common.Events.Transactions;
using Common.Helpers;
using Common.Queries.Products;
using Common.Queries.Transactions;
using DataLayer.EventHandlers;
using DataLayer.EventHandlers.Products;
using DataLayer.EventHandlers.Transactions;
using DataLayer.EventStores;
using DataLayer.ReadModels;

namespace EventSourcingIntro;

public static class ServiceConfigurator
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        SetUpDI(builder.Services);
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
    private static void SetUpDI(IServiceCollection services)
    {
        // Singletons, yuck, but it's all in-memory here so it makes sense
        services.AddSingleton<IEventStore, InMemoryEventStore>();
        services.AddSingleton<IReadModel, InMemoryReadModel>();

        services.AddSingleton<IDateTimeHelper, DateTimeHelper>();

        // Commands
        services.AddScoped<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateProductCommand>, UpdateProductCommandHandler>();

        services.AddScoped<ICommandHandler<AddTransactionCommand>, AddTransactionCommandHandler>();

        // Queries
        services.AddScoped<IQueryHandler<GetProductDetailsQuery, ProductDetailsDto>, GetProductDetailsQueryHandler>();
        services.AddScoped<IQueryHandler<GetProductsListQuery, IEnumerable<BasicProductDto>>, GetProductsListQueryHandler>();

        services.AddScoped<IQueryHandler<GetProductTransactionsQuery, IEnumerable<TransactionDto>>, GetProductTransactionsQueryHandler>();

        // Events
        services.AddScoped<IEventHandler<ProductCreatedEvent>, ProductCreatedEventHandler>();
        services.AddScoped<IEventHandler<ProductUpdatedEvent>, ProductUpdatedEventHandler>();

        services.AddScoped<IEventHandler<TransactionAddedEvent>, TransactionAddedEventHandler>();
    }
}
