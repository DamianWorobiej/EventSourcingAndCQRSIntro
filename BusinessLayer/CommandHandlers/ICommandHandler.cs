using Common.Commands;

namespace BusinessLayer.CommandHandlers;

public interface ICommandHandler<T> where T : Command
{
    Task Handle(T command);
}
