using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesStore.Filters
{
    public class PerformanceActionFilterAttribute : ActionFilterAttribute
    {
        private static Stopwatch _stopWatch = new();
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopWatch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _stopWatch.Stop();
            var millis = (_stopWatch.Elapsed.TotalMilliseconds);
            context.HttpContext.Response.Headers.Add("processing_time", millis.ToString());
        }
    }
}
