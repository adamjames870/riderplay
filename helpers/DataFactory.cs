using System;
using LiteDB;

namespace RiderTesting;
public class DataFactory : IDisposable
{

    private LiteDatabase _db;
    
    public DataFactory()
    {
        _db = new LiteDatabase(Constants.DATABASE_NAME);
    }

    public DataFactory(LiteDatabase db)
    {
        _db = db;
    }

    public ILiteCollection<NavEvent> NavEvents()
    {
        return _db.GetCollection<NavEvent>(Constants.COLLECTION_NAME);
    }

    public NavEvent PreviousEvent(NavEvent evt)
    {
        return evt.PreviousEvent(_db);
    }
    
    public void Dispose()
    {
        _db.Dispose();
    }

    public void SetupForTesting()
    {
        _db.DropCollection(Constants.COLLECTION_NAME);
            
        var col = _db.GetCollection<NavEvent>(Constants.COLLECTION_NAME);
        string[] evts =  {"Arrival", "Departure", "Noon1", "Noon2", "Arrival", "NoonPort", "Departure", "Noon"};

        ConcreteNavEvent? evt = new ConcreteNavEvent("DummyStart", -1);
        col.Insert(evt);
            
        foreach (var s in evts)
        {
            evt = new ConcreteNavEvent(s, evt.Id);
            col.Insert(evt);
        }
    }
    
}
