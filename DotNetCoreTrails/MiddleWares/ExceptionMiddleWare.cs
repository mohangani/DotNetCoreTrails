using DotNetCoreTrails.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetCoreTrails.MiddleWares
{

    /// <summary>
    /// Why Microsoft not introducing Interface for middle ware?
    /// </summary>
    public class ExceptionMiddleWare : IMiddleware
    {

        public ExceptionMiddleWare(ILogger<ExceptionMiddleWare> loger)
        {
            Loger = loger;
        }

        public ILogger Loger { get; }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            try
            {
                await next(context);
            }
            catch (TestException ex) {
                Loger.LogError(ex.ToString());
                await response.WriteAsync(ex.ToString());
            }
            catch (Exception exception)
            {
                Loger.LogError(exception.ToString());
                await response.WriteAsync(exception.Serialize());
            }
        }
    }
}
