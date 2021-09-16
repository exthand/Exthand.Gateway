
using Exthand.GatewayClient.Interface;
using Exthand.GatewayClient.Models;

using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Exthand.GatewayClient.Exceptions;
using System.Collections.Generic;
using System.Text;

namespace Exthand.GatewayClient
{
    public class GatewayService : IGatewayService
    {
        private IHttpClientFactory _httpClientFactory;

        public GatewayService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        #region UTILITIES

        /// <summary>
        /// Returns a list of activated banks for a given country.
        /// </summary>
        /// <param name="countryCode">ISO-2 of the country ("BE", "FR, etc)</param>
        /// <returns>A list of Bank objects.</returns>
        public async Task<IEnumerable<Bank>> GetBanksAsync(string countryCode)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");
            var result = await client.GetAsync("ais/banks?countryCode=" + countryCode);

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<IEnumerable<Bank>>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }

            throw new Exception(await result.Content.ReadAsStringAsync());
        }


        public async Task<string> FindFlowIdAsync(string queryString)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");
            var result = await client.GetAsync("ais/access/findFlowId?queryString=" + HttpUtility.UrlEncode(queryString));

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        #endregion

        #region PIS

        public async Task<BankPaymentAccessOption> GetBankPaymentAccessOptionsAsync(int connectorId)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");
            var result = await client.GetAsync("pis/payment/options/" + connectorId.ToString());

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<BankPaymentAccessOption>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        public async Task<PaymentInitResponse> PaymentInitiateAsync(PaymentInitRequest paymentInitRequest)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");

            var stringContent = new StringContent(JsonSerializer.Serialize<PaymentInitRequest>(paymentInitRequest), Encoding.UTF8, "application/json");

            var result = await client.PostAsync("pis/payment", stringContent);

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<PaymentInitResponse>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        public async Task<PaymentFinalizeResponse> PaymentFinalizeAsync(PaymentFinalizeRequest paymentFinalizeRequest)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");

            var stringContent = new StringContent(JsonSerializer.Serialize<PaymentFinalizeRequest>(paymentFinalizeRequest), Encoding.UTF8, "application/json");

            var result = await client.PostAsync("pis/payment/finalize", stringContent);

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<PaymentFinalizeResponse>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        public async Task<PaymentStatusResponse> PaymentStatusAsync(PaymentStatusRequest paymentStatusRequest)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");

            var stringContent = new StringContent(JsonSerializer.Serialize<PaymentStatusRequest>(paymentStatusRequest), Encoding.UTF8, "application/json");

            var result = await client.PostAsync("pis/payment", stringContent);

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<PaymentStatusResponse>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        #endregion

        #region AIS-BANK-ACCESS


        public async Task<BankAccessOption> GetBankAccessOptionsAsync(int connectorId)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");
            var result = await client.GetAsync("ais/access/option/" + connectorId.ToString());

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<BankAccessOption>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }


        /// <summary>
        /// Initiates the process of getting a consent for bank accounts. 
        /// </summary>
        /// <param name="bankAccessRequest"></param>
        /// <returns></returns>
        public async Task<BankAccessResponse> RequestBankAccessAsync(BankAccessRequest bankAccessRequest)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");

            var stringContent = new StringContent(JsonSerializer.Serialize<BankAccessRequest>(bankAccessRequest), Encoding.UTF8, "application/json");

            var result = await client.PostAsync("ais/access", stringContent);

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<BankAccessResponse>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Finalizes the request of consent. Must be called after the redirect from the bank.
        /// </summary>
        /// <param name="bankAccessRequestFinalize"></param>
        /// <returns></returns>
        public async Task<BankAccessResponseFinalize> FinalizeRequestBankAccessAsync(BankAccessRequestFinalize bankAccessRequestFinalize)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");

            var stringContent = new StringContent(JsonSerializer.Serialize<BankAccessRequestFinalize>(bankAccessRequestFinalize), Encoding.UTF8, "application/json");

            var result = await client.PostAsync("ais/access/finalize", stringContent);

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<BankAccessResponseFinalize>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Cancels a token for a given PSU and Connector.
        /// </summary>
        /// <param name="DeleteConsentRequest"></param>
        /// <returns>DeleteRequestResponse</returns>
        public async Task<bool> CancelBankAccessAsync(DeleteConsentRequest deleteConsentRequest)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");

            var stringContent = new StringContent(JsonSerializer.Serialize<DeleteConsentRequest>(deleteConsentRequest), Encoding.UTF8, "application/json");

            var result = await client.PostAsync("/ais/access/deleteconsent", stringContent);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Removes a bank account from the list of available accounts for a given user.
        /// </summary>
        /// <param name="DeleteAccountRequest"></param>
        /// <returns>DeleteAccountResponse</returns>
        public async Task<bool> RemoveBankAccountAsync(DeleteAccountRequest deleteAccountRequest)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");

            var stringContent = new StringContent(JsonSerializer.Serialize<DeleteAccountRequest>(deleteAccountRequest), Encoding.UTF8, "application/json");

            var result = await client.PostAsync("ais/access/deleteaccount", stringContent);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        public async Task<BankAccountsResponse> GetBankAccountsAsync(BankAccountsRequest bankAccountsRequest)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");

            var stringContent = new StringContent(JsonSerializer.Serialize<BankAccountsRequest>(bankAccountsRequest), Encoding.UTF8, "application/json");

            var result = await client.PostAsync("ais/accounts", stringContent);

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<BankAccountsResponse>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        #endregion

        #region AIS-TRANSACTIONS

        public async Task<BalanceResponse> GetBalancesAsync(string accountId, BalanceRequest balanceRequest)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");

            var stringContent = new StringContent(JsonSerializer.Serialize<BalanceRequest>(balanceRequest), Encoding.UTF8, "application/json");

            var result = await client.PostAsync($"ais/account{accountId}/balances", stringContent);

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<BalanceResponse>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        public async Task<TransactionResponse> GetTransactionsAsync(string accountId, TransactionRequest transactionRequest)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");

            var stringContent = new StringContent(JsonSerializer.Serialize<TransactionRequest>(transactionRequest), Encoding.UTF8, "application/json");

            var result = await client.PostAsync($"ais/accounts/{accountId}/transactions", stringContent);

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<TransactionResponse>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        public async Task<TransactionResponse> GetTransactionsNextAsync(string accountId, TransactionPagingRequest transactionRequest)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");

            var stringContent = new StringContent(JsonSerializer.Serialize<TransactionPagingRequest>(transactionRequest), Encoding.UTF8, "application/json");

            var result = await client.PostAsync($"ais/accounts/{accountId}/transactions/next", stringContent);

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<TransactionResponse>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        public async Task<TransactionResponse> GetTransactionsPreviousAsync(string accountId, TransactionPagingRequest transactionRequest)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");

            var stringContent = new StringContent(JsonSerializer.Serialize<TransactionPagingRequest>(transactionRequest), Encoding.UTF8, "application/json");

            var result = await client.PostAsync($"ais/accounts/{accountId}/transactions/previous", stringContent);

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<TransactionResponse>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        #endregion

        #region USER

        /// <summary>
        /// Gets the content of the latest Terms & Conditions, Pricvacy Notice and their Version number.
        /// </summary>
        /// <returns>TermsDTO object</returns>
        public async Task<TermsDTO> GetTCAsync()
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");
            var result = await client.GetAsync("ais/gw/tc/latest");

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<TermsDTO>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }

            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Get the latest version number of the TC & Privacy accepted by the given user.
        /// </summary>
        /// <param name="psuId">Your internal id of the user (PSU)</param>
        /// <returns>TermsValidatedDTO object</returns>
        public async Task<TermsValidated> GetTCLatestAsync(string psuId)
        {
            TermsValidated termsValidatedDTO = new()
            {
                psuId = psuId,
                Version = -1
            };

            if (string.IsNullOrEmpty(psuId))
                return termsValidatedDTO;

            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");
            var result = await client.GetAsync("ais/gw/tc/latest/" + psuId);

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<TermsValidated>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }

            throw new Exception(await result.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Creates a new user on the Gateway
        /// </summary>
        /// <param name="userDTO">A userDTO object containes info needed for Extahd:Gateway being able to manage your user (PSU)</param>
        /// <returns>ResponseActionDTO object</returns>
        public async Task<UserRegisterResponse> CreateUserAsync(UserDTO userDTO)
        {
            var client = _httpClientFactory.CreateClient("BankingSdkGatewayClient");
            var stringContent = new StringContent(JsonSerializer.Serialize<UserDTO>(userDTO), Encoding.UTF8, "application/json");
            var result = await client.PostAsync("/ais/gw/user/register", stringContent);

            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<UserRegisterResponse>(await result.Content.ReadAsStringAsync());
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonSerializer.Deserialize<Error>(await result.Content.ReadAsStringAsync());
                throw new GatewayException(error.Message);
            }
            throw new Exception(await result.Content.ReadAsStringAsync());

        }


        #endregion


    }
}
