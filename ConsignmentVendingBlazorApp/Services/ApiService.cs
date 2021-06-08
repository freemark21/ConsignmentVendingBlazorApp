using ConsignmentVendingBlazorApp.Models;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Logging;
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
        public ILogger _logger;

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

            var body = $"{{\r\n {quote}request{quote}: {{\r\n " +
                        $"{quote}companyNumber{quote}: {cono},\r\n " +
                        $"{quote}operatorInit{quote}: {quote}sys{quote},\r\n " +
                        $"{quote}operatorPassword{quote}: {quote}{quote},\r\n " +
                        $"{quote}productCode{quote}: {quote}{replenexNumber}{quote},\r\n " +
                        $"{quote}unitOfMeasure{quote}: {quote}{unitOfMeasure}{quote},\r\n " +
                        $"{quote}warehouse{quote}: {quote}{whse}{quote},\r\n " +
                        $"{quote}useCrossReferenceFlag{quote}: {quote}false{quote},\r\n " +
                        $"{quote}includeUnavailableInventory{quote}: {quote}false{quote},\r\n " +
                        $"{quote}tInfieldvalue{quote}: {{\r\n " +
                        $"{quote}t-infieldvalue{quote}: []\r\n }}\r\n }}\r\n }}";

            StringContent content = new(body, Encoding.UTF8, "application/json");

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

        public async Task<List<OrderSubmitResponse>> OrderSubmitAsync(Token token, List<ReturnModel> returns)
        {
            List<OrderSubmitResponse> orderSubmitResponses = new();
            var quote = "\"";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.AccessToken);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<ReturnModel> distinctQuery = returns.GroupBy(elem => new { elem.Cono, elem.CustomerNumber, elem.ShipTo }).Select(group => group.First()).ToList();
            foreach (ReturnModel distinctReturn in distinctQuery)
            {
                var lineCounter = 1;
                var body = $"{{\r\n {quote}request{quote}: {{\r\n " +
                            $"{quote}companynumber{quote}: {distinctReturn.Cono},\r\n " +
                            $"{quote}operatorinit{quote}: {quote}sys{quote},\r\n " +
                            $"{quote}operatorpassword{quote}: {quote}{quote},\r\n " +
                            $"{quote}sxt_orderv4{quote}: {{\r\n " +
                            $"{quote}sxt_orderv4{quote}: [\r\n{{\r\n " +
                            $"{quote}actiontype{quote}: {quote}storefront{quote},\r\n " +
                            $"{quote}bofl{quote}: {quote}false{quote},\r\n " +
                            $"{quote}transtype{quote}: {quote}RM{quote},\r\n" +
                            $"{quote}whse{quote}: {quote}{distinctReturn.Whse}{quote},\r\n" +
                            $"{quote}takenby{quote}: {quote}Cons{quote},\r\n" +
                            $"{quote}buyer{quote}: {quote}Consignment{quote},\r\n" +
                            $"{quote}orderNo{quote}: {quote}0{quote},\r\n" +
                            $"{quote}orderSuf{quote}: {quote}0{quote}\r\n}}\r\n]\r\n}}," +
                            $"{quote}sxt_customer{quote}: {{\r\n {quote}sxt_customer{quote}: [\r\n{{\r\n" +
                            $"{quote}custNo{quote}: {quote}{distinctReturn.CustomerNumber}{quote}\r\n}}\r\n]\r\n}},\r\n" +
                            $"{quote}sxt_itemV4{quote}: {{\r\n{quote}sxt_itemV4{quote}: [\r\n";
                List<ReturnModel> groupOfOrders = returns.Where(line => distinctReturn.Cono == line.Cono && distinctReturn.CustomerNumber == line.CustomerNumber && distinctReturn.ShipTo == line.ShipTo).ToList();
                foreach (var line in groupOfOrders)
                {
                    body += $"{{\r\n" +
                            $"{quote}qtyOrd{quote}: {quote}{line.Qty}{quote},\r\n" +
                            $"{quote}qtyUom{quote}: {quote}{line.UnitOfIssue}{quote},\r\n" +
                            $"{quote}sellerProd{quote}: {quote}{line.ReplenexNumber}{quote}\r\n}}\r\n";
                    if (groupOfOrders.Count() != lineCounter)
                    {
                        body += ",";
                    }
                    lineCounter++;
                }
                body += $"]\r\n}},\r\n" +
                        $"{quote}sxt_shipfm{quote}: {{\r\n {quote}sxt_shipfm{quote}: [\r\n{{\r\n" +
                        $"{quote}shipFmNo{quote}: {quote}{quote}\r\n}}\r\n]\r\n}},\r\n" +
                        $"{quote}sxt_shipto{quote}: {{\r\n {quote}sxt_shipto{quote}: [\r\n{{\r\n" +
                        $"{quote}shipToNo{quote}: {quote}{distinctReturn.ShipTo}{quote}\r\n}}\r\n]\r\n}},\r\n" +
                        $"{quote}sxt_billto{quote}: {{\r\n {quote}sxt_billto{quote}: [\r\n{{\r\n}}\r\n]\r\n}},\r\n" +
                        $"{quote}sxt_terms{quote}: {{\r\n {quote}sxt_terms{quote}: [\r\n{{\r\n" +
                        $"{quote}sxTermsCd{quote}: {quote}{quote}\r\n}}\r\n]\r\n}},\r\n" +
                        $"{quote}sxt_schedule{quote}: {{\r\n {quote}sxt_schedule{quote}: [\r\n{{\r\n" +
                        $"{quote}seqNo{quote}: 0 \r\n}}\r\n]\r\n}},\r\n" +
                        $"{quote}sxt_total{quote}: {{\r\n {quote}sxt_total{quote}: [\r\n{{\r\n" +
                        $"{quote}totLn{quote}: {quote}0{quote} \r\n}}\r\n]\r\n}}," +
                        $"{quote}sxt_header_extra{quote}: {{\r\n {quote}sxt_header_extra{quote}: [\r\n{{\r\n" +
                        $"{quote}SeqNo{quote}: 0 \r\n}}\r\n]\r\n}},\r\n" +
                        $"{quote}sxt_line_extra{quote}: {{\r\n {quote}sxt_line_extra{quote}: [\r\n{{\r\n" +
                        $"{quote}SeqNo{quote}: 0 \r\n}}\r\n]\r\n}},\r\n" +
                        $"{quote}sxt_line_component{quote}: {{\r\n {quote}sxt_line_component{quote}: [\r\n{{\r\n}}\r\n]\r\n}}\r\n}}";

                StringContent content = new(body, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(OEfullOrdMntCall, content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    orderSubmitResponses.Add(JsonConvert.DeserializeObject<OrderSubmitResponse>(jsonResponse));
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            return orderSubmitResponses;
        }
    }
}
