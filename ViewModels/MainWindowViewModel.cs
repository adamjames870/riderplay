using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Media;
using LiteDB;

namespace RiderTesting.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    public ObservableCollection<NavEventViewModel> EventList { get; } = new();
    
    public MainWindowViewModel()
    {

        using (var db = new LiteDatabase(Constants.DATABASE_NAME))
        {
            
            db.DropCollection(Constants.COLLECTION_NAME);
            
            var col = db.GetCollection<NavEvent>(Constants.COLLECTION_NAME);
            string[] evts =  {"Arrival", "Departure", "Noon1", "Noon2", "Arrival", "NoonPort", "Departure", "Noon"};

            ConcreteNavEvent? evt = new ConcreteNavEvent("DummyStart", -1);
            col.Insert(evt);
            
            foreach (var s in evts)
            {
                evt = new ConcreteNavEvent(s, evt.Id);
                col.Insert(evt);
            }
            
            col.EnsureIndex(x => x.Id);
            var returnedEvent = col.FindById(col.Max());

            while (returnedEvent != null)
            {
                EventList.Add(new NavEventViewModel(returnedEvent));
                returnedEvent = returnedEvent.PreviousEvent(db);
            }

        }
        
    }
    

}