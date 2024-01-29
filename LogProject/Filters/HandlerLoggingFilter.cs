using LogService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using static LogProject.Filters.HandlerLoggingFilter;

namespace LogProject.Filters
{
    public class HandlerLoggingFilter : ActionFilterAttribute
    {
        public HandlerLoggingFilter()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var _services = context.HttpContext.RequestServices;
            var _configuration = _services.GetService<IConfiguration>();

            if (IsTracingEnabled(_configuration) &&
                IsMatchingTraceId(_configuration, context.HttpContext.Connection.Id))
            {
                var request = context.HttpContext.Request;
                var messages = $"{request.Path}{request.QueryString}";

                TraceDebug(_services, JsonConvert.SerializeObject(messages));
            }

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var _services = context.HttpContext.RequestServices;
            var _configuration = _services.GetService<IConfiguration>();

            if (context.Exception is null &&
                IsTracingEnabled(_configuration) &&
                IsMatchingTraceId(_configuration, context.HttpContext.Connection.Id))
            {
                var result = context.Result;

                TraceDebug(_services, JsonConvert.SerializeObject(result));
            }

            base.OnActionExecuted(context);
        }

        private bool IsTracingEnabled(IConfiguration configuration)
        {
            return configuration is not null && configuration.GetSection("TraceIssue:IsTrace").Get<bool>();
        }

        private bool IsMatchingTraceId(IConfiguration configuration, string connectionId)
        {
            var traceModel = configuration.GetSection("TraceIssue:TraceModel").Get<TraceModel>();
            return traceModel?.Id is not null && traceModel.Id.Contains(connectionId);
        }

        private void TraceDebug(IServiceProvider service, string messages)
        {
            var debugService = service.GetService<IDebugService>();

            if (debugService is not null)
            {
                debugService.Debug(JsonConvert.SerializeObject(messages));
            }
        }

        public class TraceModel
        {
            public string Id { get; set; }
        }
    }
}
