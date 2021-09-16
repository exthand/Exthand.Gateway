using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exthand.GatewayClient.Models
{
    public class TransactionRequest
    {
        public int ConnectorId { get; set; }
        public string UserContext { get; set; }
        public BankSettings BankSettings { get; } = null;
        public TppContext TppContext { get; set; }
        public string psuIp { get; set; }

    }

    public class TransactionPagingRequest
    {
        public int ConnectorId { get; set; }
        public string UserContext { get; set; }
        public BankSettings BankSettings { get; } = new();
        public TppContext TppContext { get; set; }
        public string psuIp { get; set; }
        public string PagerContext { get; set; }

    }

}
