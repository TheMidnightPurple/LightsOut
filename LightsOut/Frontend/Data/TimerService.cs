using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace LightsOut.Data
{
    public class TimerService : BackgroundService
    {
        public static event Func<String, Task> UpdateEvent;
        //public static event Func<DateTime, Task> UpdateEvent;
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(60000);//tempo que se espera até ação(1 minuto)
                UpdateEvent?.Invoke("o");
            }
        }
    }
}