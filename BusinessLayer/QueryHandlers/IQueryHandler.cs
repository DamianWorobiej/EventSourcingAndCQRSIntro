using Common.Queries;

namespace BusinessLayer.QueryHandlers;

public interface IQueryHandler<TQuery, TResult> 
    where TQuery : Query 
    where TResult : class
{
    Task<TResult> Handle(TQuery query);
}
