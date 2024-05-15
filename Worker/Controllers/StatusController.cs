using WorkerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using System;
using System.Text.Encodings.Web;
using System.Web;

namespace WindowsServiceApiDemo.Controllers
{
    [ApiController]
    [Route("status")]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private string RunningMessage() => $"Status: <b>{Worker.ApiCommand}</b>";

        public StatusController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ContentResult SetCommand()
        {
            //Worker.ApiCommand = apiCommand;
            //_logger.LogInformation(RunningMessage());
            var fileHtml = System.IO.File.ReadAllText("Content\\template-default.html", Encoding.UTF8);

            if (Worker.isRunningService1)
            {
                fileHtml = fileHtml.Replace("{{STATUS_SERVICE1}}", "success");
                fileHtml = fileHtml.Replace("{{STATUS_SERVICE2}}", "grey");
                fileHtml = fileHtml.Replace("{{STATUS_SERVICE3}}", "grey");
            }

            if (Worker.isRunningService2)
            {
                fileHtml = fileHtml.Replace("{{STATUS_SERVICE2}}", "success");
                fileHtml = fileHtml.Replace("{{STATUS_SERVICE1}}", "grey");
                fileHtml = fileHtml.Replace("{{STATUS_SERVICE3}}", "grey");
            }

            if (Worker.isRunningService3)
            {
                fileHtml = fileHtml.Replace("{{STATUS_SERVICE3}}", "success");
                fileHtml = fileHtml.Replace("{{STATUS_SERVICE1}}", "grey");
                fileHtml = fileHtml.Replace("{{STATUS_SERVICE2}}", "grey");
            }

            fileHtml = fileHtml.Replace("{{DT_EXEC_SERVICE1}}", Worker.lastRunService1.ToString("dd/MM/yyyy HH:mm:ss"));
            fileHtml = fileHtml.Replace("{{DT_EXEC_SERVICE2}}", Worker.lastRunService2.ToString("dd/MM/yyyy HH:mm:ss"));
            fileHtml = fileHtml.Replace("{{DT_EXEC_SERVICE3}}", Worker.lastRunService3.ToString("dd/MM/yyyy HH:mm:ss"));

            return base.Content(fileHtml, "text/html");
        }
    }
}
