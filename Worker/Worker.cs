using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public static string ApiCommand { get; set; } = "no command";

        public static bool isRunningService1 {get; set;} = false;
        public static DateTime lastRunService1 { get; set; } = DateTime.MinValue;
        public static bool isRunningService2 { get; set; } = false;
        public static DateTime lastRunService2 { get; set; } = DateTime.MinValue;
        public static bool isRunningService3 { get; set; } = false;
        public static DateTime lastRunService3 { get; set; } = DateTime.MinValue;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected static void SetVariables(string whoIsRunning)
        {
            switch(whoIsRunning) 
            {
                case "service1":
                    isRunningService1 = true;
                    isRunningService2 = false;
                    isRunningService3 = false;
                    lastRunService1 = DateTime.Now;
                    break;
                case "service2":
                    isRunningService1 = false;
                    isRunningService2 = true;
                    isRunningService3 = false;
                    lastRunService2 = DateTime.Now;
                    break;
                case "service3":
                    isRunningService1 = false;
                    isRunningService2 = false;
                    isRunningService3 = true;
                    lastRunService3 = DateTime.Now;
                    break;
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}, command: {string}", DateTimeOffset.Now, ApiCommand);

                //ApiCommand = SetText("Iniciando o serviço");
                SetVariables("service1");
                await Task.Delay(10000, stoppingToken);

                SetVariables("service2");
                await Task.Delay(10000, stoppingToken);

                SetVariables("service3");
                await Task.Delay(10000, stoppingToken);
            }
        }

        private static string SetText(string text)
            => HttpUtility.HtmlEncode(text);    
    }
}

