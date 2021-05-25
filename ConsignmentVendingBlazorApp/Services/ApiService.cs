using ConsignmentVendingBlazorApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public async Task<decimal> GetWhseProdAvail(string cono, string customerNumber, string replenexNumber, string unitOfMeasure, string whse, Token token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.AccessToken);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var quote = "\"";
            var body = $"{{\r\n {quote}request{quote}: {{\r\n {quote}companyNumber{quote}: {cono},\r\n {quote}operatorInit{quote}: {quote}sys{quote},\r\n {quote}operatorPassword{quote}: {quote}{quote},\r\n {quote}productCode{quote}: {quote}{replenexNumber}{quote},\r\n {quote}unitOfMeasure{quote}: {quote}{unitOfMeasure}{quote},\r\n {quote}warehouse{quote}: {quote}{whse}{quote},\r\n {quote}useCrossReferenceFlag{quote}: {quote}false{quote},\r\n {quote}includeUnavailableInventory{quote}: {quote}false{quote},\r\n {quote}tInfieldvalue{quote}: {{\r\n {quote}t-infieldvalue{quote}: []\r\n }}\r\n }}\r\n }}";
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(WhseAvailCall, content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    WhseProdAvailResponse.Rootobject responseRootObject = JsonConvert.DeserializeObject<WhseProdAvailResponse.Rootobject>(jsonResponse);
                    if (responseRootObject.Response is null)
                    {
                        return -99;
                    }
                    WhseProdAvailResponse.Response responseContent = responseRootObject.Response;
                    return responseContent.DistributorNetAvailable;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
        }



    }
}
