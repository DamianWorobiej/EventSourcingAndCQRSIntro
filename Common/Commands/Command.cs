namespace Common.Commands;

public abstract class Command
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
