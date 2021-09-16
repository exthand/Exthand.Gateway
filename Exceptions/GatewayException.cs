using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exthand.GatewayClient.Exceptions
{
    public class GatewayException : Exception
    {
        public GatewayException(string message) : base(message)
        {
        }
    }
}
