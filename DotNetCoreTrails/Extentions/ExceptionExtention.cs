using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetCoreTrails.MiddleWares
{
    public static class ExceptionExtention
    {
        public static string Serialize(this Exception ex) {

            return JsonSerializer.Serialize(new { Message = ex?.Message }, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }      

    }
}
