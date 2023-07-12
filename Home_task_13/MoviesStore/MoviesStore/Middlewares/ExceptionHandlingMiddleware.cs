using BLL.Services.Helpers.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MoviesStore.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, ILogger<ExceptionHandlingMiddleware> logger)
        {
            try
            {
                await _next(context);
            }
            catch(NotFoundException ex)
            {
                await HandleException(context, ex, logger, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex, logger, HttpStatusCode.InternalServerError);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex, ILogger<ExceptionHandlingMiddleware> logger, HttpStatusCode errorCode)
        {
            logger.LogError(ex.ToString());
            var errorMessage = JsonConvert.SerializeObject(new { ex.Message, ex.InnerException });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorCode;

            return context.Response.WriteAsync(errorMessage);
        }
    }
}
