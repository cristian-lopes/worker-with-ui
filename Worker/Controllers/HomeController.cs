using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WindowsServiceApiDemo.Controllers
{
    [ApiController]
    [Route("Home")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private const string runningMessage = "<b>Worker Multi-Services</b> is running...<br><br>Click <a href='/status'>here</a> to view service execution details!";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ContentResult Get()
        {
            _logger.LogInformation(runningMessage);
            return base.Content(runningMessage, "text/html");
        }
    }
}
