using System.Collections.Generic;

namespace Exthand.GatewayClient.Models
{
    public class PaymentInitiationRequestOptions
    {
        public RecipientInfoOptions Recipient { get; set; } = new RecipientInfoOptions();
        public DebtorInfoOptions Debtor { get; set; } = new DebtorInfoOptions();
        public PaymentInitiationRequestOptionsType EndToEndId { get; set; } = PaymentInitiationRequestOptionsType.Required;
        public PaymentInitiationRequestOptionsType RequestedExecutionDate { get; set; } = PaymentInitiationRequestOptionsType.Optional;
        public PaymentInitiationRequestOptionsType RegulatoryReportingCodeRequired { get; set; } = PaymentInitiationRequestOptionsType.Unused;
        public List<RegulatoryReportingCodeOptions> RegulatoryReportingCodes { get; set; } = new List<RegulatoryReportingCodeOptions>();
    }
}