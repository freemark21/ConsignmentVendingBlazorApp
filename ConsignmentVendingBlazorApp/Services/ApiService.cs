using ConsignmentVendingBlazorApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsignmentVendingBlazorApp.Services
{
    public class ApiService
    {
        public HttpClient _httpClient;

        public ApiService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<Token> GetToken()
        {

            var form = new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"username", ServiceAccountAccessKey},
                    {"password", ServiceAccountSecretKey},
                    {"client_id", ResourceOwnerClientId},
                    {"client_secret", ResourceOwnerClientSecret},
                    {"client secret scope", "" }
                };

            HttpResponseMessage tokenResponse = await _httpClient.PostAsync(OAuth2TokenEndpoint, new FormUrlEncodedContent(form));
            var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
            Token token = JsonConvert.DeserializeObject<Token>(jsonContent);
            return token;
        }

        public async Task<WhseProdAvailResponse> GetWhseProdAvail(string cono, string customerNumber, string replenexNumber, string unitOfMeasure, string whse)
        {
            var form = new Dictionary<string, string>
            {
                {"companyNumber", cono },
                {"operatorInit", "sys" },
                {"operatorPassword", "" },
                {"productCode", replenexNumber },
                {"unitOfMeasure", unitOfMeasure },
                {"warehouse", whse },
                {"useCrossReferenceFlag", "false" },
                {"includeUnavailableInventory", "false" },
            };
            throw new NotImplementedException();
        }


        public class Token
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }

            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; }
        }
    }
}
