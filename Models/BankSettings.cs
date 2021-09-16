using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exthand.GatewayClient.Models
{
    public class BankSettings
    {
        public string NcaId { get; set; }
        public string AppClientId { get; set; }
        public string AppClientSecret { get; set; }
        public string TlsCertificateName { get; set; }
        public string TlsCertificatePassword { get; set; }
        public string SigningCertificateName { get; set; }
        public string SigningCertificatePassword { get; set; }
        public string AppApiKey { get; set; }
        public string PemFileUrl { get; set; }
        public string SigningCertificateKeyId { get; set; }
        public string TlsCertificateKeyId { get; set; }
        public string EncryptionCertificateName { get; set; }
        public string EncryptionCertificatePassword { get; set; }
        public string EncryptionCertificateKeyId { get; set; }

        public string BankTlsPublicKeyName { get; set; }
        public string BankSigningPublicKeyName { get; set; }
        public string BankEncryptionPublicKeyName { get; set; }
    }
}
