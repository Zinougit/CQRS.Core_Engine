using CQRS.Core.Command;

namespace CQRS.Core.ICommandDispatcher ;
public interface ICommandDispatcher {
    void Register<T>(Func<T,Task> hendler) where T : BaseCommand; 
    Task Send(BaseCommand command);
}