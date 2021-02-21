using DotNetCoreTrails.Exceptions;
using Microsoft.AspNetCore.Http;
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
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            try
            {
                await next(context);
            }
            catch (TestException ex) {

                await response.WriteAsync(ex.ToString());
            }
            catch (Exception exception)
            {
                await response.WriteAsync(exception.Serialize());
            }
        }
    }
}
