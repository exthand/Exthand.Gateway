
namespace Exthand.GatewayClient.Models
{
    public class TierAddressOptions
    {
        public PaymentInitiationRequestOptionsType AddressType { get; set; }
        public PaymentInitiationRequestOptionsType Department { get; set; }
        public PaymentInitiationRequestOptionsType SubDepartment { get; set; }
        public PaymentInitiationRequestOptionsType StreetName { get; set; }
        public PaymentInitiationRequestOptionsType BuildingNumber { get; set; }
        public PaymentInitiationRequestOptionsType PostCode { get; set; }
        public PaymentInitiationRequestOptionsType TownName { get; set; }
        public PaymentInitiationRequestOptionsType CountrySubDivision { get; set; }
        public PaymentInitiationRequestOptionsType Country { get; set; }
        public PaymentInitiationRequestOptionsType AddressLine { get; set; }

        public TierAddressOptions() : this(PaymentInitiationRequestOptionsType.Unused)
        {
        }

        public TierAddressOptions(PaymentInitiationRequestOptionsType option)
        {
            AddressType = option;
            Department = option;
            SubDepartment = option;
            StreetName = option;
            BuildingNumber = option;
            PostCode = option;
            TownName = option;
            CountrySubDivision = option;
            Country = option;
            AddressLine = option;
        }
    }
}