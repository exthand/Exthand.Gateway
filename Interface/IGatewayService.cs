using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Exthand.GatewayClient.Models;

namespace Exthand.GatewayClient.Interface
{
    public interface IGatewayService
    {
        Task<bool> CancelBankAccessAsync(DeleteConsentRequest deleteConsentRequest);
        public Task<UserRegisterResponse> CreateUserAsync(UserDTO userDTO);
        Task<BankAccessResponseFinalize> FinalizeRequestBankAccessAsync(BankAccessRequestFinalize bankAccessRequestFinalize);
        Task<string> FindFlowIdAsync(string queryString);
        Task<BalanceResponse> GetBalancesAsync(string accountId, BalanceRequest balanceRequest);
        public Task<BankAccessOption> GetBankAccessOptionsAsync(int connectorId);
        Task<BankAccountsResponse> GetBankAccountsAsync(BankAccountsRequest bankAccountsRequest);
        Task<BankPaymentAccessOption> GetBankPaymentAccessOptionsAsync(int connectorId);
        public Task<IEnumerable<Bank>> GetBanksAsync(string countryCode);
        public Task<TermsDTO> GetTCAsync();
        public Task<TermsValidated> GetTCLatestAsync(string psuId);
        Task<TransactionResponse> GetTransactionsAsync(string accountId, TransactionRequest transactionRequest);
        Task<TransactionResponse> GetTransactionsNextAsync(string accountId, TransactionPagingRequest transactionRequest);
        Task<PaymentFinalizeResponse> PaymentFinalizeAsync(PaymentFinalizeRequest paymentFinalizeRequest);
        Task<PaymentInitResponse> PaymentInitiateAsync(PaymentInitRequest paymentInitRequest);
        Task<PaymentStatusResponse> PaymentStatusAsync(PaymentStatusRequest paymentStatusRequest);
        Task<bool> RemoveBankAccountAsync(DeleteAccountRequest deleteAccountRequest);
        public Task<BankAccessResponse> RequestBankAccessAsync(BankAccessRequest bankAccessRequest);
    }
}
