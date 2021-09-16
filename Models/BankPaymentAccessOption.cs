using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exthand.GatewayClient.Models
{

    public class BankPaymentAccessOption
    {
        public int debtorIban { get; set; }

        public SepaCreditTransfers sepaCreditTransfers { get; set; } = new SepaCreditTransfers();
        public InstantSepaCreditTransfers instantSepaCreditTransfers { get; set; } = new InstantSepaCreditTransfers();
        public CrossborderSepaCreditTransfers crossborderSepaCreditTransfers { get; set; } = new CrossborderSepaCreditTransfers();
        public Target2Payment target2Payment { get; set; } = new Target2Payment();
        public List<AdditionalPropertyRequested> additionalPropertiesRequested { get; set; } = new List<AdditionalPropertyRequested>();
    }

    public class SepaCreditTransfers
    {
        public SinglePayments singlePayments { get; set; } = new SinglePayments();
        public PeriodicPayments periodicPayments { get; set; } = new PeriodicPayments();
        public BulkPayments bulkPayments { get; set; } = new BulkPayments();

    }

    public class SinglePayments
    {
        public bool supported { get; set; }
        public bool cancelSupported { get; set; }
    }
    public class PeriodicPayments
    {
        public bool supported { get; set; }
        public bool cancelSupported { get; set; }
    }
    public class BulkPayments
    {
        public bool supported { get; set; }
        public bool cancelSupported { get; set; }
    }

    public class InstantSepaCreditTransfers
    {
        public SinglePayments singlePayments { get; set; }
        public PeriodicPayments periodicPayments { get; set; }
        public BulkPayments bulkPayments { get; set; }
    }

    public class CrossborderSepaCreditTransfers
    {
        public SinglePayments singlePayments { get; set; }
        public PeriodicPayments periodicPayments { get; set; }
        public BulkPayments bulkPayments { get; set; }
    }

    public class Target2Payment
    {
        public SinglePayments singlePayments { get; set; }
        public PeriodicPayments periodicPayments { get; set; }
        public BulkPayments bulkPayments { get; set; }
    }

    public class AdditionalPropertyRequested
    {
        public String name { get; set; }
        public String title { get; set; }
        public bool required { get; set; }
        public String description { get; set; }
        public String template { get; set; }
    }

}

