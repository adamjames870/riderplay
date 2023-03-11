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

        using (var db = new DataFactory())
        {
            
            db.SetupForTesting();
            var NavEvents = db.NavEvents();
            int countEvt = NavEvents.Count();
            int max = NavEvents.Max();

            var returnedEvent = NavEvents.FindById(NavEvents.Max());

            while (returnedEvent != null)
            {
                EventList.Add(new NavEventViewModel(returnedEvent));
                returnedEvent = db.PreviousEvent(returnedEvent);
            }

        }
        
    }
    

}