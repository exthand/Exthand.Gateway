using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exthand.GatewayClient.Models
{
    public class TransactionResponse
    {
        public IEnumerable<Transaction> transactions { get; set; }
        public string userContext { get; set; }
        public string pagerContext { get; set; }
        public bool isFirstPage { get; set; }
        public bool isLastPage { get; set; }
        public string rawResponse { get; set; }
    }


    public class Transaction
    {

        public string id { get; set; }
        public decimal amount { get; set; }
        public string counterpartReference { get; set; }
        public string counterpartName { get; set; }
        public string counterpartBic { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public DateTime? executionDate { get; set; }
        public DateTime? valueDate { get; set; }
        public TransactionRemittanceInformation remittanceInformation { get; set; }
        public TransactionBankTransactionCode bankTransactionCode { get; set; }
    }

    public class TransactionRemittanceInformation
    {
        public TransactionRemittanceInformationStructured structured { get; set; }
        public string unstructured { get; set; }
    }
    public class TransactionRemittanceInformationStructured
    {
        public TransactionCreditorReferenceInformation creditorReferenceInformation { get; set; }
    }
    public class TransactionCreditorReferenceInformation
    {
        public TransactionCreditorReferenceInformationType type { get; set; }
        public string reference { get; set; }
    }

    public class TransactionCreditorReferenceInformationType
    {
        public string code { get; set; }
        public string issuer { get; set; }
    }



    public class TransactionBankTransactionCode
    {
        public string domain { get; set; }
        public string family { get; set; }
        public string subFamily { get; set; }
    }

}
