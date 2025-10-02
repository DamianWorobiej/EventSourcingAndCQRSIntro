namespace Common.Events;

public abstract class Event
{
    public int Id { get; set; }
    public abstract Guid StreamId { get; }
}
