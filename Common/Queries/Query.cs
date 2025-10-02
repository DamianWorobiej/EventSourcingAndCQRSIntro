namespace Common.Queries;

public abstract class Query
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
