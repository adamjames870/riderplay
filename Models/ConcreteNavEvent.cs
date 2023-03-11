using System;

namespace RiderTesting;
public class ConcreteNavEvent : NavEvent
{
    
    // TODO this is to be removed, only used for playing / experimenting
    // Many methods implemented here should be pushed back up to Abstract parent

    public ConcreteNavEvent()
    {
    }

    public ConcreteNavEvent(string name, int precedingId, DateTime dt) : base(name, precedingId, dt) { }

    public override TimeSpan TimeSinceLastEvent()
    {
        throw new NotImplementedException();
    }
    
    
}
