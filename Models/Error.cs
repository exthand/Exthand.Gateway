using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Exthand.GatewayClient.Models
{
    public class Error
    {

        [JsonPropertyName("exceptionType")]
        public string ExceptionType { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("innerException")]
        public string InnerException { get; set; }

        [JsonPropertyName("statusCode")]
        public int? StatusCode { get; set; }

        [JsonPropertyName("userContext")] public string UserContext { get; set; }
        [JsonPropertyName("log")] public string Log { get; set; }
    }
}
