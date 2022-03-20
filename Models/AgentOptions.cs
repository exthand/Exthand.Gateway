namespace Exthand.GatewayClient.Models
{
    public class AgentOptions
    {
        public PaymentInitiationRequestOptionsType Country = PaymentInitiationRequestOptionsType.Unused;
        public PaymentInitiationRequestOptionsType BicFi = PaymentInitiationRequestOptionsType.Optional;
    }
}