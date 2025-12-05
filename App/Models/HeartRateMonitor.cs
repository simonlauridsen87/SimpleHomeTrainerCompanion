namespace App.Models;

public class HeartRateMonitor
{   
    private int _heartRate;
    private readonly Random _random = new();
    public delegate void NotifyDelegate(int hr);
    
    public NotifyDelegate? OnHeartRateChanged;
    
    public void Init()
    {
        Task.Run(Run);
    }

    private async Task Run()
    {
        while (true)
        {
            _heartRate = _random.Next(60, 100);        
            OnHeartRateChanged?.Invoke(_heartRate);
            
            await Task.Delay(1000);
        }
    }
}