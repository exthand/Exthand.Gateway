using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exthand.GatewayClient.Models
{
    public class BankAccountsResponse
    {
        public string userContext { get; set; }
        public BankAccountResponse[] accounts {get;set;}

    }

    public class BankAccountResponse
    {
        public string id { get; set; }
        public string currency { get; set; }
        public string iban { get; set; }

        public string description { get; set; }

        public TransactionsConsent transactionsConsent { get; set; }
        public BalancesConsent balancesConsent { get; set; }
    }


    public class TransactionsConsent
    {
        public string consentId { get; set; }
        public DateTime? validUntil { get; set; }
    }

    public class BalancesConsent
    {
        public string consentId { get; set; }
        public DateTime? validUntil { get; set; }
    }
}
