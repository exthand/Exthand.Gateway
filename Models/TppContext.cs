using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exthand.GatewayClient.Models
{
    public class TppContext
    {
        public string TppId { get; set; }
        public string App { get; set; }
        public string Flow { get; set; }
        public string Transaction { get; set; }
        public string Unit { get; set; }
    }
}
