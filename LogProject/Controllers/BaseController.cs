using LogProject.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogProject.Controllers
{
    [HandlerLoggingFilter]
    [HandlerExceptionFilter]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }
    }
}
