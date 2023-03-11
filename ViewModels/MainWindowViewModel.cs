using System.Collections.Generic;
using System.Collections.ObjectModel;
using LiteDB;

namespace RiderTesting.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    //public string Greeting => "Found: ";
    public string Greeting { get; set; }
    public ObservableCollection<NavEventViewModel> EventList { get; } = new();
    
    public MainWindowViewModel()
    {

        Greeting = "Found: ";
        using (var db = new LiteDatabase("eventdb.db"))
        {
            
            var col = db.GetCollection<NavEvent>("NavEvents");
            // ConcreteNavEvent Arr = new("Arrival");
            // ConcreteNavEvent Dep = new("Departure");
            // ConcreteNavEvent Noon = new("Noon");
            // col.Insert(Arr);
            // col.Insert(Dep);
            // col.Insert(Noon);
            foreach (NavEvent item in col.FindAll())
            {
                Greeting += $"{item.Name}(id: {item.Id}), ";
                EventList.Add(new NavEventViewModel(item));
            }

        }
        
    }
    

}