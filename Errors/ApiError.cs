using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPI.Errors
{
    public class ApiError
    {
       

        public int StatusCode { get; set; }
        public string Message { get; set; }
       

        public override string ToString()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(this,options);
        }
    }
}
