using System.Reflection;
using CQRS.Core.Event;

namespace CQRS.Core.Domain;

public abstract class AggregateRoot {
    protected bool IsActive;
    protected Guid _id;
    public int Version = -1;
    public Guid Id {
        get{
            return _id;
        }
    }
    private readonly List<BaseEvent> _changes = new();

    public IEnumerable<BaseEvent> GetUncommitedChages(){
        return _changes;
    }
    public void ClearUncommitedChages(){
        _changes.Clear();
    }

    protected void ApplyChages(BaseEvent @event, bool IsNew){
        MethodInfo? methodInfo = this.GetType().GetMethod("Apply", new Type[] {@event.GetType()});
        var method = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo),"The Apply method for this Event is not implemented");
        method.Invoke(this, new object[] {@event});

        if(IsNew){
            _changes.Add(@event);
        } 
    }

     protected void RaiseEvent(BaseEvent @event){
        ApplyChages(@event,true);
     }

    public void ReplayEvent(IEnumerable<BaseEvent> events){
        foreach(var @event in events){
            ApplyChages(@event, false);
        }
    }
}