using BankingSDK.Common.Enums;

namespace BankingSDK.Common.Models
{
    public class AgentOptions
    {
        public PaymentInitiationRequestOptionsType Country = PaymentInitiationRequestOptionsType.Unused;
        public PaymentInitiationRequestOptionsType BicFi = PaymentInitiationRequestOptionsType.Optional;
    }
}