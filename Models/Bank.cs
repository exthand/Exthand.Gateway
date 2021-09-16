using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exthand.GatewayClient.Models
{
    public class Bank
    {

        public string fullname { get; set; }

        public int connectorID { get; set; }

        public string logoURL { get; set; }

        public string countryISO { get; set; }

        public int status { get; set; }

    }
}
