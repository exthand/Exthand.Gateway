using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exthand.GatewayClient.Models
{
    public class BalanceResponse
    {

        public IEnumerable<Balance> Balances { get; set; }
        public string UserContext { get; set; }
        public string RawResponse { get; set; }

    }


    public class Balance
    {

        public string BalanceType { get; }
        public string RawBalanceType { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public DateTime? LastChangeDateTime { get; set; }
        public BalanceAmount BalanceAmount { get; set; }
    }

    public class BalanceAmount
    {

        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
