using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MoviesStore.Middlewares
{
    
    public class ValidateApiMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _apiKey;
        public ValidateApiMiddleware(RequestDelegate next, string apiKey)
        {
            _apiKey = apiKey;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers.TryGetValue("api_key", out StringValues actualKey);
            if (actualKey != _apiKey)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }
            await _next(context);
        }
    }
}
