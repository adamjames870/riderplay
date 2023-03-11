using System;
using LiteDB;

namespace RiderTesting;
public abstract class NavEvent
{

    public int Id { get; set; }
    public int PrecedingId { get; set; }
    
    public string IsPlannedOrActual { get; set; } // TBC exactly how we do this
    
    public string Name { get; set; }
    public string Type { get; set; } // Have to work out if we need this, as every event is different class
    
    public DateTime DateAndTime { get; set; }
    public bool DateAndTimeIsFixed { get; set; }
    
    public int DistanceSinceLastEvent { get; set; } // In nautical miles

    public abstract TimeSpan TimeSinceLastEvent(); // Probably will not be abstract in the end

    public NavEvent? PreviousEvent(LiteDatabase db)
    {
        var col = db.GetCollection<NavEvent>(Constants.COLLECTION_NAME);
        return PrecedingId > 0 ? col.FindById(PrecedingId) : null;
    }

}
