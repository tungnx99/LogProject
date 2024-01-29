using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace LogProject.Filters
{
    public class HandlerExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var error = context.Exception;
            if (error != null)
            {
                var message = new
                {
                    Code = "Contact Admin!",
                    Message = error.Message
                };

                context.Result = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(message),
                    ContentType = "application/json",
                    // change to whatever status code you want to send out
                    StatusCode = (int?)HttpStatusCode.BadRequest
                };
            }
        }
    }
}
