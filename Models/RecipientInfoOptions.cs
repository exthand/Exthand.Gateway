using System.Collections.Generic;
using BankingSDK.Common.Enums;
using BankingSDK.Common.Models.Data;

namespace BankingSDK.Common.Models
{
    public class RecipientInfoOptions
    {
        public PaymentInitiationRequestOptionsType Name { get; set; } = PaymentInitiationRequestOptionsType.Required;
        public PaymentInitiationRequestOptionsType AccountIdentification { get; set; } = PaymentInitiationRequestOptionsType.Required;
        public List<AccountSchemeType> AccountSchemes { get; set; } = new List<AccountSchemeType>() { AccountSchemeType.IBAN };
        public PaymentInitiationRequestOptionsType Currency { get; set; } = PaymentInitiationRequestOptionsType.Unused;
        public TierAddressOptions PostalAddress { get; set; } = new TierAddressOptions();
        public AgentOptions Agent { get; set; } = new AgentOptions();
    }
}