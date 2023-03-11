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

        using (var db = new LiteDatabase("eventdb.db"))
        {
            
            db.DropCollection("NavEvents");
            
            var col = db.GetCollection<NavEvent>("NavEvents");
            string[] evts =  {"Arrival", "Departure", "Noon1", "Noon2", "Arrival", "NoonPort", "Departure", "Noon"};

            ConcreteNavEvent? evt = null;
            foreach (var s in evts)
            {
                evt = evt == null ? new ConcreteNavEvent("DummyStart", -1) : new ConcreteNavEvent(s, evt.Id);
                col.Insert(evt);
            }
            
            foreach (NavEvent item in col.FindAll())
            {
                EventList.Add(new NavEventViewModel(item));
            }

        }
        
    }
    

}