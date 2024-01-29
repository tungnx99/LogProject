using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Interfaces;

namespace LogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : BaseController
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService) : base()
        {
            _testService = testService;
        }

        [HttpPost]
        public IActionResult PushMessage(string message)
        {
            return Ok(_testService.SendMessage(message));
        }
    }
}
