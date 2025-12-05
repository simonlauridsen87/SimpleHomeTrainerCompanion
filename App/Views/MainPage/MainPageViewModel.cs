using System.ComponentModel;
using System.Runtime.CompilerServices;
using App.Models;

namespace App;

public class MainPageViewModel : INotifyPropertyChanged
{
    private HeartRateMonitor _heartRateMonitor;
    
    public int HeartRate
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public MainPageViewModel()
    {
        _heartRateMonitor = new HeartRateMonitor();
        _heartRateMonitor.OnHeartRateChanged += hr => HeartRate = hr;
        _heartRateMonitor.Init();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}