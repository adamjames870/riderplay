using System;
using RiderTesting.ViewModels;

namespace RiderTesting;
public class NavEventViewModel : ViewModelBase
{
    public readonly NavEvent _NavEvent;
    
    public NavEventViewModel(NavEvent navEvent)
    {
        _NavEvent = navEvent;
    }

    public string Name => _NavEvent.Name;
    public string Id => _NavEvent.Id.ToString();
    
    public string DateAndTime => $"{_NavEvent.DateAndTime:dd-MM-yyyy HHmm}";
    
}
