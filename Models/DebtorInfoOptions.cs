using System.Collections.Generic;
using BankingSDK.Common.Enums;
using BankingSDK.Common.Models.Data;

namespace BankingSDK.Common.Models
{
    public class DebtorInfoOptions
    {
        public PaymentInitiationRequestOptionsType Name { get; set; } = PaymentInitiationRequestOptionsType.Optional;
        public PaymentInitiationRequestOptionsType AccountIdentification { get; set; } = PaymentInitiationRequestOptionsType.Required;
        public List<AccountSchemeType> AccountSchemes { get; set; } = new List<AccountSchemeType>() { AccountSchemeType.IBAN };
        public PaymentInitiationRequestOptionsType Currency { get; set; } = PaymentInitiationRequestOptionsType.Optional;
        public PaymentInitiationRequestOptionsType Email { get; set; } = PaymentInitiationRequestOptionsType.Optional;
        public PaymentInitiationRequestOptionsType PhoneNumber { get; set; } = PaymentInitiationRequestOptionsType.Optional;
        public TierAddressOptions PostalAddress { get; set; } = new TierAddressOptions();
    }
}