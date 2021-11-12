using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exthand.GatewayClient.Models;

namespace Exthand.GatewayClient.Exceptions
{
    public class GatewayException : Exception
    {

        public Error Error { get; set; }

        public GatewayException(Error error) : base(error.Message)
        {
            this.Error = error;
        }
    }
}
